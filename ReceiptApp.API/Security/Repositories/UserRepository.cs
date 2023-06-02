using Microsoft.EntityFrameworkCore;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Shared;
using ReceiptApp.API.Shared.Persistence.Repository;

namespace ReceiptApp.API.Security.Repositories;

public class UserRepository : BaseRepository<User, Guid>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<User?> FindByUsername(string username)
    {
        return await _dbSet.FirstOrDefaultAsync(user => user.Username == username);
    }
}