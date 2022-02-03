using MediatR;
using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IMediator _mediator;
    private readonly IFileReadWrite _fileReadWrite;

    private readonly List<Pet> _pet = new();
    public PetService(IFileReadWrite fileReadWrite)
    {
        _fileReadWrite = fileReadWrite;
        _pet.Add(new Pet {PetId = 1, PetName = "Ice", Category = Category.Bunny, PetStatus = PetStatus.Available});
        _pet.Add(new Pet {PetId = 2, PetName = "Donna", Category = Category.Dog, PetStatus = PetStatus.Pending});
        _pet.Add(new Pet {PetId = 3, PetName = "Max", Category = Category.Cat, PetStatus = PetStatus.Sold});
    }
    public List<Pet> GetPets()
    {
        return _fileReadWrite.Read();
        // return _pet;
    }
    public async Task<Pet> AddPet(AddPetCommand request)
    {
        Pet p = new()
        {
            PetId = _pet.Max(x => x.PetId) + 1,
            PetName = request.PetName,
            Category = Category.Bunny,
            PetStatus = PetStatus.Available,
        };
        _pet.Add(p);
        await _fileReadWrite.Write(p);
        return p;
    }
    public Pet DeletePet(Pet pet)
    {
        _pet.Remove(pet);
        _fileReadWrite.Write(pet);
        return pet;
    }
    public Pet EditPet(Pet pet, string petName)
    {
        pet.PetName = petName;
        _fileReadWrite.Write(pet);
        return pet;
    }
}
    