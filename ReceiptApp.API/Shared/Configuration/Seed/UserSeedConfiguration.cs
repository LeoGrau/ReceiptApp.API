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
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("admin"),
                Firstname = "Leonardo",
                Lastname = "Grau"
            }, 
            new User
            {
                Id = new Guid("4ee82c0c-c190-4732-a111-dd74d6e743cf"),
                Username = "cooluser",
                Description = "Just a sample 2",
                HashedPassword = BCrypt.Net.BCrypt.HashPassword("1234"),
                Firstname = "Fabrizio",
                Lastname = "Barra"
            });
    }
}