using PetStoreApp.Domain.Factories;

namespace PetStoreApp.Infrastructure.Repositories;

public class FileRepository<T> : IFileRepository<T> where T : class
{
    private readonly IFiles _files;
    private string fileName;
    private string setFile;
    private readonly PetFactory _petFactory;


    public FileRepository(IFiles files, PetFactory petFactory, string setFile)
    {
        _files = files;
        _petFactory = petFactory;
        this.setFile = setFile;
    }

    public FileRepository<T> SetFile(string fileName)
    {
        this.setFile = setFile;
        return this;
    }

    public async Task<T> AddAsync(T entity, string fileName)
    {
        List<T> list = new List<T>();
        list = await GetAllAsync(fileName);
        list.Add(entity);
        await _files.WriteToTextFile<T>(fileName, list);
        return entity;
    }

    public async Task<T> DeleteAsync(T entity, string fileName)
    {
        List<T> list = new List<T>();
        list = await GetAllAsync(fileName);
        list.Remove(entity);
        await _files.WriteToTextFile<T>(fileName, list);
        return entity;
    }

    public async Task<List<T>> GetAllAsync(string fileName)
    {
        return await _files.ReadFromTextFile<T>(fileName);
    }

    public async Task<List<T>> UpdateAsync(T entity, string entity2, string fileName)
    {
        return await _files.WriteToTextFile<T>(fileName, list);
    }
}

