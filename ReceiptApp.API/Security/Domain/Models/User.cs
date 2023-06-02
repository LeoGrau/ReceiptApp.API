namespace ReceiptApp.API.Security.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string? HashedPassword { get; set; }
    public string? Description { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }

    // Relation
    public IList<Receipt>? Receipts { get; set; }
}