using System.ComponentModel.DataAnnotations.Schema;
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

    [Column(TypeName = "varchar(30)")] public Currencies Currency { get; set; }
    [Column(TypeName = "varchar(30)")] public DocumentTypes DocumentType { get; set; }
    
    // From relation
    public Guid UserId { get; set; }
    public User? User { get; set; }


    public void UpdateReceipt(Receipt updatedReceipt)
    {
        LogoImageUrl = updatedReceipt.LogoImageUrl;
        Amount = updatedReceipt.Amount;
        Title = updatedReceipt.Title;
        Description = updatedReceipt.Description;
        Address = updatedReceipt.Address;
        IdentificationNumber = updatedReceipt.IdentificationNumber;
        Currency = updatedReceipt.Currency;
        DocumentType = updatedReceipt.DocumentType;
    }

}