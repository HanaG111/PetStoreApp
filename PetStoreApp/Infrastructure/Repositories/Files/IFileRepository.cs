namespace PetStoreApp.Infrastructure.Repositories.Files;
public interface IFileRepository
{
    Task<List<T>> WriteToFile<T>(string fileName, List<T> list);
    Task<List<T>> ReadFromFile<T>(string fileName);
}