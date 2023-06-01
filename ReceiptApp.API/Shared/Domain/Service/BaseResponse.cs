namespace ReceiptApp.API.Shared.Domain.Service;

public class BaseResponse<TEntity>
{
    public TEntity? Resource { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public BaseResponse(TEntity? resource)
    {
        Message = string.Empty;
        Resource = resource;
        Success = true;
    }

    public BaseResponse(string message)
    {
        Message = message;
        Resource = default;
        Success = false;
    }
}