namespace PetStoreApp.Infrastructure.Repositories;

public interface IFileRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(string fileName);
    Task<T> AddAsync(T entity, string fileName);
    Task<List<T>> UpdateAsync(T entity, string entity2, string fileName);
    Task<T> DeleteAsync(T entity, string fileName);
}