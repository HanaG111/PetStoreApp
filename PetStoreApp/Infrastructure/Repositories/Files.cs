using System.Text;
using System.Text.Json;

namespace PetStoreApp.Infrastructure.Repositories;
public class Files
{
    public async Task<List<T>> WriteToTextFile<T>(string fileName, List<T> list)
    {
        string json = JsonSerializer.Serialize(list);
        await File.WriteAllTextAsync(fileName + ".txt", json);
        return list;
    }
    public async Task<List<T>> ReadFromTextFile<T>(string fileName)
    {
        List<T> list = new List<T>();
        string read;
        try
        {
            using (var reader = new StreamReader(fileName + ".txt", Encoding.Default))
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
        return await Task.FromResult(list);
    }
}