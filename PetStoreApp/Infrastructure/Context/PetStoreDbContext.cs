using PetStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Infrastructure.Context;

public class PetStoreDbContext : DbContext
{
    public PetStoreDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetProperties()
                         .Where(p => p.ClrType == typeof(string))))


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetStoreDbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }
}