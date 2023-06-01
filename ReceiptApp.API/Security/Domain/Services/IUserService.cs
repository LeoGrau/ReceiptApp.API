using ReceiptApp.API.Security.Domain.Models;

namespace ReceiptApp.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindAsync(Guid id);
    Task RegisterAsync(Guid id, User user);
}