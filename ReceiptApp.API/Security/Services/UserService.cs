using System.Net;
using AutoMapper;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Domain.Services.Communication;
using ReceiptApp.API.Security.Domain.Services.Communication.Request;
using ReceiptApp.API.Security.Exceptions;
using ReceiptApp.API.Security.Resources.Show;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> FindAsync(Guid id)
    {
        var existingUser = await _userRepository.FindAsync(id);
        if (existingUser == null)
            throw new AppException("User not found exception", HttpStatusCode.NotFound);
        return existingUser;
    }
    
    

    public async Task RegisterAsync(RegisterRequest registerRequest)
    {
        var existingUserWithUsername = await _userRepository.FindByUsername(registerRequest.Username!);
        if (existingUserWithUsername != null)
            throw new AppException("User with that username already exists!");

        // Map Request to User
        var user = _mapper.Map<RegisterRequest, User>(registerRequest);
        
        // Hash Password
        user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
        
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException(e.Message);
        }
    }

    public async Task<AuthResponse> AuthenticateAsync(AuthRequest authRequest)
    {
        var existingUsernameOrEmail = await _userRepository.FindByUsername(authRequest.Username!);
        if (existingUsernameOrEmail == null ||
            !BCrypt.Net.BCrypt.Verify(authRequest.Password, existingUsernameOrEmail.HashedPassword))
        {
            return new AuthResponse("Authentication failed.");
        }
        // await _userRepository.SetRolesFromUser(existingUsernameOrEmail.Id!.Value);
        var authResource = _mapper.Map<User, AuthResource>(existingUsernameOrEmail);
        //authResource.Token = _jwtHandler.GenerateToken(existingUsernameOrEmail);
        return new AuthResponse(authResource);
    }
}