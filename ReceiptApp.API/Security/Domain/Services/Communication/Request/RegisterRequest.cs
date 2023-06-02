namespace ReceiptApp.API.Security.Domain.Services.Communication.Request;

public class RegisterRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}