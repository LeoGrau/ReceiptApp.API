using ReceiptApp.API.Shared.Domain.Enum;

namespace ReceiptApp.API.Security.Resources.Create;

public class CreateReceiptResource
{
    public Guid UserId { get; set; }
    public string? LogoImageUrl { get; set; }
    public float Amount { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public long IdentificationNumber { get; set; }
    
    // Currencies
    public Currencies Currency { get; set; }
    public DocumentTypes DocumentType { get; set; }
}