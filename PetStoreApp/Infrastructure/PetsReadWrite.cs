using System.Text.Json;
using MediatR;
using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;
public class PetsReadWrite : IPetsReadWrite
{
    private readonly IPetService _petService;
    private readonly IMediator _mediator;

    public List<Pet> Read()
    {
        List<Pet> pets = new List<Pet>();
        
        var text = File.ReadAllText("DbPets.txt");

        pets = JsonSerializer.Deserialize<List<Pet>>(text);
        
        // await File.WriteAllTextAsync("DbPets.txt", json);
        //
        // var lines = System.IO.File.ReadAllLines("DbPets.txt");

        // pets = lines.ToList<Pet>();
        // foreach (var line in lines)
        // {
        //     Console.WriteLine("\t" + line);
        // }
        // Console.WriteLine("Press any key to exit.");
        // System.Console.ReadKey();
        return pets;
    }
    public async Task Write(Pet pet)
    {
        List<Pet> pets= new List<Pet>();
        pets.Add(pet);

        string json = JsonSerializer.Serialize(pets);
        // List<String> petobj= new List<String>();
        // petobj.Add(json);

        await File.WriteAllTextAsync("DbPets.txt", json);

        // await File.AppendAllLinesAsync("DbPets.txt", pets);
    }
}
