using Microsoft.EntityFrameworkCore;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Shared.Persistence.Repository;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext appDbContext)
    {
        _dbSet = appDbContext.Set<TEntity>();
    }

    public async Task<TEntity?> FindAsync(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity newEntityObject)
    {
        await _dbSet.AddAsync(newEntityObject);
    }

    public void Update(TEntity updatedEntityObject)
    {
        _dbSet.Update(updatedEntityObject);
    }

    public void Remove(TEntity toDeleteEntity)
    {
        _dbSet.Remove(toDeleteEntity);
    }

    public async Task<bool> Exists(TKey id)
    {
        return await _dbSet.FindAsync(id) != null;
    }
}