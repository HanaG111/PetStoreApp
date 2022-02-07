using MediatR;
using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IMediator _mediator;
    private readonly IPetsReadWrite _petsReadWrite;

    private readonly List<Pet> _pet = new();
    public PetService(IPetsReadWrite petsReadWrite)
    {
        _petsReadWrite = petsReadWrite;
    }
    public List<Pet> GetPets()
    {
        return _petsReadWrite.Read();
        // return _pet;
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
        await _petsReadWrite.Write(p);
        return p;
    }
    public async Task<Pet> DeletePet(Pet pet)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        await _petsReadWrite.Remove(pet);
        return pet;
    }
    public async Task<Pet> EditPet(Pet pet, string petName)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        pet.PetName = petName;
        await _petsReadWrite.Edit(pet, petName);
        return pet;
    }
}
    