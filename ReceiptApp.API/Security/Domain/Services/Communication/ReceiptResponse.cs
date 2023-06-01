using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Shared.Domain.Service;

namespace ReceiptApp.API.Security.Domain.Services.Communication;

public class ReceiptResponse : BaseResponse<Receipt>
{
    public ReceiptResponse(Receipt? resource) : base(resource)
    {
    }

    public ReceiptResponse(string message) : base(message)
    {
    }
}