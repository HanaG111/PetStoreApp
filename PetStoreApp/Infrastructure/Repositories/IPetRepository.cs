namespace PetStoreApp.Infrastructure.Repositories;

public interface IPetRepository < T > where T: class {
    Task<List<T>> GetAllAsync(string entity);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity, T entity2);
    Task<T> DeleteAsync(T entity);
}