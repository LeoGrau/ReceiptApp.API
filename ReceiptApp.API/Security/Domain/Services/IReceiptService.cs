using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Security.Domain.Services.Communication;

namespace ReceiptApp.API.Security.Domain.Services;

public interface IReceiptService
{
    Task<IEnumerable<Receipt>> ListAsync();
    Task<IEnumerable<Receipt>> ListByUserIdAsync(Guid userId);
    Task<ReceiptResponse> FindAsync(Guid id);
    Task<ReceiptResponse> AddAsync(Receipt receipt);
    Task<ReceiptResponse> Remove(Guid id);
    Task<ReceiptResponse> UpdateAsync(Guid id, Receipt updatedReceipt);
}