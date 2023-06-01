using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Shared.Domain.Enum;

namespace ReceiptApp.API.Shared.Configuration.Seed;

public class ReceiptSeedConfiguration :  IEntityTypeConfiguration<Receipt>
{
    public void Configure(EntityTypeBuilder<Receipt> builder)
    {
        builder.HasData(new Receipt
        {
            Id = new Guid("286b8b8e-145d-4a81-b33a-8b8e752d1585"),
            Title = "Some random title",
            Description = "Some description",
            Address = "Jr Guzman Barro 541, BA De Centenario, Independecia",
            UserId = new Guid("ed159590-32de-4828-a20b-61c0b026b556"),
            Currency = Currencies.Sol,
            DocumentType = DocumentTypes.Dni,
            Amount = 4000.2F,
            IdentificationNumber = 7656353,
            LogoImageUrl = "https://www.f5.com/content/dam/f5-com/page-assets-en/home-en/services/professional-services/guardian-partners/controlware-logo.png"
        });
    }
}