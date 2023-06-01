namespace ReceiptApp.API.Shared.Domain.Repository;

public interface IBaseRepository<TEntity, in TKey>
{
    Task<TEntity?> FindAsync(TKey id);
    Task AddAsync(TEntity newEntityObject);
    void Update(TEntity updatedEntityObject);
    void Remove(TEntity toDeleteEntity);
    Task<bool> Exists(TKey id);
}