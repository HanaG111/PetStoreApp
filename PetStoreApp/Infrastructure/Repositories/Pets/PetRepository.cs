using PetStoreApp.Infrastructure.Repositories.Files;

namespace PetStoreApp.Infrastructure.Repositories.Pets;
public class PetRepository<T> : IPetRepository<T> where T: class {
    private readonly IFileRepository _fileRepository;
    private const string fileName = "Pets.txt";
    public async Task<T> AddAsync(T entity)
    {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>();
        list.Add(entity);
        await _fileRepository.WriteToFile<T>(fileName, list);
        return entity;
    }
    public async Task<T> DeleteAsync(T entity)
    {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>();
        list.Remove(entity);
        await _fileRepository.WriteToFile<T>(fileName, list);
        return entity;
    }
    public async Task<List<T>> GetAllAsync<T>() {
        return await _fileRepository.ReadFromFile<T>(fileName);
    }
    public async Task<List<T>> UpdateAsync(T entity, string entity2) {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>();
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            // list.Find(x => x.entity == entity);
            return await _fileRepository.WriteToFile(fileName, list);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}