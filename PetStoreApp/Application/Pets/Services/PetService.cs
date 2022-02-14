using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Repositories.Pet;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;
    private readonly List<Pet> _pet = new();
    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }
    public List<Pet> GetPets()
    {
        return _petRepository.Read();
    }
    public async Task<Pet> AddPet(AddPetCommand request)
    {
        Pet p = new()
        {
            PetId = GetPets().Max(x => x.PetId) + 1,
            PetName = request.PetName,
            Category = Category.Bunny,
            PetStatus = PetStatus.Available,
        };
        _pet.Add(p);
        await _petRepository.Write(p);
        return p;
    }
    public async Task<Pet> DeletePet(Pet pet)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        await _petRepository.Remove(pet);
        return pet;
    }
    public async Task<Pet> EditPet(Pet pet, string petName)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        pet.PetName = petName;
        await _petRepository.Edit(pet, petName);
        return pet;
    }
}
    