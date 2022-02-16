using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure.Repositories.Pets;
public interface IPetRepository<T> where T: class {
    Task<List<T>> GetAllAsync<T>();
    Task<T> AddAsync(T entity);
    Task<List<T>> UpdateAsync(T entity, string entity2);
    Task<T> DeleteAsync(T entity);
}