using PetStoreApp.Domain.Interfaces;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;


namespace PetStoreApp.Infrastructure.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly PetStoreDbContext Db;

    protected readonly DbSet<TEntity> DbSet;

    protected Repository(PetStoreDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual async Task AddPet(TEntity entity)
    {
        DbSet.AddPet(entity);
        await SaveChanges();
    }

    public virtual async Task<List<TEntity>> GetPets()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> FindById(int petId)
    {
        return await DbSet.FindAsync(petId);
    }
        
    public virtual async Task EditPet(TEntity entity)
    {
        DbSet.EditPet(entity);
        await SaveChanges();
    }

    public virtual async Task DeletePet(TEntity entity)
    {
        DbSet.DeletePet(entity);
        await SaveChanges();
    }

    public virtual async Task FindByStatus(TEntity entity)
    {
        DbSet.FindByStatus(entity);
        await SaveChanges();
    }

    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }

    public void Dispose()
    {
        Db?.Dispose();
    }
}