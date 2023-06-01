using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services.Communication;

namespace ReceiptApp.API.Security.Domain.Services;

public interface IReceiptService
{
    Task<IEnumerable<Receipt>> ListAsync();
    Task<ReceiptResponse> FindAsync(Guid id);
    Task<ReceiptResponse> AddAsync(Receipt receipt);
    Task<ReceiptResponse> Remove(Guid id);
}