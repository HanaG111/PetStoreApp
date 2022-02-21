namespace PetStoreApp.Infrastructure.Repositories;

public interface IFiles
{
    Task<List<T>> WriteToTextFile<T>(string fileName, List<T> list);
    Task<List<T>> ReadFromTextFile<T>(string fileName);
}