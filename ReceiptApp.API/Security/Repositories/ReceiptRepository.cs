using Microsoft.EntityFrameworkCore;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Repositories;
using ReceiptApp.API.Shared;
using ReceiptApp.API.Shared.Persistence.Repository;

namespace ReceiptApp.API.Security.Repositories;

public class ReceiptRepository : BaseRepository<Receipt, Guid>, IReceiptRepository
{
    public ReceiptRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<IEnumerable<Receipt>> ListAsync()
    {
        return await _dbSet.ToListAsync();
    }
    
    public async Task<IEnumerable<Receipt>> ListByUserIdAsync(Guid userId)
    {
        return await _dbSet.Where(receipt => receipt.UserId == userId).ToListAsync();
    }
}