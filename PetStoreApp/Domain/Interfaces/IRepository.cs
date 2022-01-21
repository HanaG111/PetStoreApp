using PetStoreApp.Domain.Models;

namespace PetStoreApp.Domain.Interfaces;
public interface IRepository<TEntity> : IDisposable where TEntity : Entity
{
    Task AddPet(TEntity entity);
    Task<List<TEntity>> GetPets();
    Task<TEntity> FindById(int petId);
    Task<TEntity>FindByStatus(string status);
    Task EditPet(TEntity entity);
    Task DeletePet(TEntity entity);
}