using System.Text.Json;
using System.Text.RegularExpressions;
using MediatR;
using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Repositories.Pet;

namespace PetStoreApp.Infrastructure.Repositories.Pet;
public class PetRepository : IPetRepository
{
    private readonly IPetService _petService;
    private readonly IMediator _mediator;

    public List<Pet> Read()
    {
        List<Pet> pets= new List<Pet>();
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
        if (File.ReadAllText("DbPets.txt").Length == 0)
        {
            List<Pet> pets = new List<Pet>();
            pets.Add(pet);
            string json = JsonSerializer.Serialize(pets);
            await File.WriteAllTextAsync("DbPets.txt", json);
        }
        else
        {
            List<Pet> pets = Read();
            pets.Add(pet);
            string json = JsonSerializer.Serialize(pets);
            await File.WriteAllTextAsync("DbPets.txt", json);
        }
    }

    public async Task Remove(Pet pet)
    {
        List<Pet> pets = Read();
        pets.RemoveAll(x => x.PetId == pet.PetId);
        string json = JsonSerializer.Serialize(pets);
        await File.WriteAllTextAsync("DbPets.txt", json);
    }
    
    public async Task Edit(Pet pet, string petName)
    {
        // var pets = await File.ReadAllTextAsync("DbPets.txt");
        // pets = Regex.Replace(pets, pet.PetName, petName);
        // await File.WriteAllLinesAsync("DbPets.txt", new[] {pets});
        // pet.PetName = petName;
        // var json = JsonSerializer.Serialize(pets);
        // await File.WriteAllTextAsync("DbPets.txt", json);
        List<Pet> pets = Read();
        pets.RemoveAll(x => x.PetId == pet.PetId);
        pets.Add(pet = new Pet());
        string json = JsonSerializer.Serialize(pets);
        await File.WriteAllTextAsync("DbPets.txt", json);
    }
}
