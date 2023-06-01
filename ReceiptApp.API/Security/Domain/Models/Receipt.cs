using ReceiptApp.API.Shared.Domain.Enum;

namespace ReceiptApp.API.Security.Domain.Models;

public class Receipt
{
    public Guid Id { get; set; }
    public string? LogoImageUrl { get; set; }
    public float Amount { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public long IdentificationNumber { get; set; }

    public Currencies Currency { get; set; }
    public DocumentTypes DocumentType { get; set; }
    
    // From relation
    public Guid UserId { get; set; }
    public User? User { get; set; }

}