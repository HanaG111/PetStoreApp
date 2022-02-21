namespace PetStoreApp.Infrastructure.Repositories;

public class FileRepository<T> : IFileRepository<T> where T : class
{
    private readonly IFiles _files;

    public FileRepository(IFiles files)
    {
        _files = files;
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
        List<T> list = new List<T>();
        list = await GetAllAsync(fileName);
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            // list.Find(x => x.entity == entity);
            return await _files.WriteToTextFile(fileName, list);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}