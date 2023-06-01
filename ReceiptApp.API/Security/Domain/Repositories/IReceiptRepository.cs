using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services.Communication;
using ReceiptApp.API.Shared.Domain.Repository;

namespace ReceiptApp.API.Security.Domain.Repositories;

public interface IReceiptRepository : IBaseRepository<Receipt, Guid>
{
    Task<IEnumerable<Receipt>> ListAsync();
}