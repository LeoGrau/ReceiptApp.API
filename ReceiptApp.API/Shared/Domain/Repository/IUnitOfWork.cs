namespace ReceiptApp.API.Shared.Domain.Repository;

public interface IUnitOfWork
{
    Task CompleteAsync();
}