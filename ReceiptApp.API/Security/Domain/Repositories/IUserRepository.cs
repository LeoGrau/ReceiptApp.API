using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Security.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User, Guid>
{
    Task<IEnumerable<User>> ListAsync();
    Task<User?> FindByUsername(string username);
}