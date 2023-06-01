using System.Net;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Security.Domain.Services;
using ReceiptApp.API.Security.Exceptions;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
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
    
    

    public Task RegisterAsync(Guid id, User user)
    {
        throw new NotImplementedException();
    }
}