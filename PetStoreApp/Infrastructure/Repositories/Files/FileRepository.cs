using System.Text;
using System.Text.Json;

namespace PetStoreApp.Infrastructure.Repositories.Files;

public class FileRepository : IFileRepository
{
    private readonly IFileRepository _fileRepository;
    private IPetRepository _petRepository;
    public async Task<List<T>> WriteToFile<T>(string fileName, List<T> list)
    {
        string json = JsonSerializer.Serialize(list);
        await File.WriteAllTextAsync(fileName, json);
        return list;
    }
    public async Task<List<T>> ReadFromFile<T>(string location)
    {
        List<T> list = new List<T>();
        string read;
        try
        {
            using (var reader = new StreamReader(location, Encoding.Default))
            {
                while ((read=reader.ReadLine()) != null)
                {
                    list = JsonSerializer.Deserialize<List<T>>(read);
                }
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return list;
    }
}


