using PetStoreApp.Infrastructure.Repositories.Files;

namespace PetStoreApp.Infrastructure.Repositories;
public class PetRepository <T> : IPetRepository <T> where T: class {
    
    private readonly IFileRepository _fileRepository;
    private const string fileName = "Pets.txt";
    public async Task<T> AddAsync(T entity)
    {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>(fileName);
        list.Add(entity);
        await _fileRepository.WriteToFile<T>(fileName, list);
        return entity;
    }
    public async Task<T> DeleteAsync(T entity) 
    {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>(fileName);
        list.Remove(entity);
        await _fileRepository.WriteToFile<T>(fileName, list);
        return entity;
    }
    public async Task<List<T>> GetAllAsync<T>(string entity) {
        return await _fileRepository.ReadFromFile<T>(fileName);
    }
    public async Task<List<T>> UpdateAsync<T>(T entity) {
        List<T> list = new List<T>();
        list = await GetAllAsync<T>(fileName);
        list.Find(x => x.fileName ==  )
        return await _fileRepository.WriteToFile(fileName);
    }
}