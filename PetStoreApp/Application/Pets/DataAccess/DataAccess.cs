using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.DataAccess;
public class DataAccess : IDataAccess
{
    private readonly List<PetModel> _pet = new();
    public DataAccess()
    {
        _pet.Add(new PetModel {PetId = 1, PetName = "Ice", Category = "Dog", Status = "Available"});
        _pet.Add(new PetModel {PetId = 2, PetName = "Donna", Category = "Cat", Status = "Pending"});
    }
    public List<PetModel> GetPets()
    {
        return _pet;
    }
    public PetModel AddPet(string petName, string category, string status)
    {
        PetModel p = new()
        {
            PetId = _pet.Max(x => x.PetId) + 1,
            PetName = petName,
            Category = category,
            Status = status
        };
        return p;
    }
    public PetModel DeletePet(PetModel pet)
    {
        var pets = GetPets();
        pets.Remove(pet);
        return pet;
    }
    public PetModel EditPet(string petName, string category, string status)
    {
        PetModel p = new PetModel
        {
            PetName = petName,
            Category = category,
            Status = status,
            PetId = _pet.Max(x => x.PetId),
        };
        _pet.Add(p);
        return p;
    }
}