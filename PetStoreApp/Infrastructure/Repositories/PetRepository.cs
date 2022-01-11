using PetStoreApp.Domain.Interfaces;
using PetStoreApp.Presentation.Controllers;
using PetStoreApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure.Repositories;

public class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(PetStoreDbContext context) : base(context) { }

    public override async Task<List<Pet>> GetPets()
    {
        return await Db.Pets.AsNoTracking().Include(p => p.Category)
            .OrderBy(p => p.PetName)
            .ToListAsync();
    }

    public override async Task<Pet> FindById(int petId)
    {
        return context.Set<TEntity>().Find(petId);
    }

    public async Task<IEnumerable<Pet>> FindByStatus(string status)
    {
        return context.Set<TEntity>().Find(p => p.Status == status);
    }
}