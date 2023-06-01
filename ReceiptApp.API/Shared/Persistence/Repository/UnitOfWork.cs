using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Shared.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
       await _appDbContext.SaveChangesAsync();
    }
}