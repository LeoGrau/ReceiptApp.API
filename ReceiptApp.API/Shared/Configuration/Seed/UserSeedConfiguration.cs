using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReceiptApp.API.Security.Domain.Models;

namespace ReceiptApp.API.Shared.Configuration.Seed;

public class UserSeedConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(
            new User
            {
                Id = new Guid("ed159590-32de-4828-a20b-61c0b026b556"), 
                Username = "admin",
                Description = "Just a sample",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("admin")
            });
    }
}