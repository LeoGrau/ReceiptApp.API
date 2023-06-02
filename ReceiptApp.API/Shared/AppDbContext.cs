using Microsoft.EntityFrameworkCore;
using ReceiptApp.API.Security.Domain;
using ReceiptApp.API.Security.Domain.Models;
using ReceiptApp.API.Shared.Configuration.Seed;
using ReceiptApp.API.Shared.Extensions;

namespace ReceiptApp.API.Shared;

public class AppDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Users
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<User>().Property(user => user.Id).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<User>().Property(user => user.Username).IsRequired();
        modelBuilder.Entity<User>().Property(user => user.HashedPassword).IsRequired();
        modelBuilder.Entity<User>().Property(user => user.Description);
        modelBuilder.Entity<User>().Property(user => user.Firstname);
        modelBuilder.Entity<User>().Property(user => user.Lastname);
        
        // Receipts
        modelBuilder.Entity<Receipt>().ToTable("Receipts");
        modelBuilder.Entity<Receipt>().HasKey(receipt => receipt.Id);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Id).ValueGeneratedOnAdd().IsRequired();
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.LogoImageUrl);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Description);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Title);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Address);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Currency);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.DocumentType);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.IdentificationNumber);
        modelBuilder.Entity<Receipt>().Property(receipt => receipt.Amount);
        modelBuilder.Entity<Receipt>()
            .HasOne(receipt => receipt.User)
            .WithMany(user => user.Receipts)
            .HasForeignKey(receipt => receipt.UserId);



        modelBuilder.ApplyConfiguration(new UserSeedConfiguration());
        modelBuilder.ApplyConfiguration(new ReceiptSeedConfiguration());
        
        modelBuilder.ConvertAllToSnakeCase();
    }
}