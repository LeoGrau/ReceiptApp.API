using ReceiptApp.API.Security.Resources.Show;
using ReceiptApp.API.Shared.Domain.Service;

namespace ReceiptApp.API.Security.Domain.Services.Communication;

public class AuthResponse : BaseResponse<AuthResource>
{
    public AuthResponse(AuthResource? resource) : base(resource)
    {
    }

    public AuthResponse(string message) : base(message)
    {
    }
}