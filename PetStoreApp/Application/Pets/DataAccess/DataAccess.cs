using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.DataAccess;

public class DataAccess : IDataAccess
{
    private readonly List<PetModel> _pet = new();

    public DataAccess()
    {
        _pet.Add(new PetModel {PetId = 1, PetName = "Ice", Category = "Dog", Status = "Available"});
        _pet.Add(new PetModel {PetId = 2, PetName = "Donna", Category = "Cat", Status = "Available"});
    }

    public List<PetModel> GetPets()
    {
        return _pet;
    }

    public PetModel AddPet(string petName, string category, string status)
    {
        PetModel p = new() {PetName = petName};
        p.PetId = _pet.Max(x => x.PetId) + 1;
        _pet.Add(p);
        return p;
    }
}