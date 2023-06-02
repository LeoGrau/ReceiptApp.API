using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services.Communication;
using ReceiptApp.API.Security.Domain.Services.Communication.Request;

namespace ReceiptApp.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindAsync(Guid id);
    Task RegisterAsync(RegisterRequest registerRequest);
    Task<AuthResponse> AuthenticateAsync(AuthRequest authRequest);
}