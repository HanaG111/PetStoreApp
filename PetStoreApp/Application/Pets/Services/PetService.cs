using MediatR;
using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IMediator _mediator;

    private readonly List<Pet> _pet = new();
    public PetService()
    {
        _pet.Add(new Pet {PetId = 1, PetName = "Ice", Category = Category.Bunny, PetStatus = PetStatus.Available});
        _pet.Add(new Pet {PetId = 2, PetName = "Donna", Category = Category.Dog, PetStatus = PetStatus.Pending});
        _pet.Add(new Pet {PetId = 3, PetName = "Max", Category = Category.Cat, PetStatus = PetStatus.Sold});
    }
    public List<Pet> GetPets()
    {
        return _pet;
    }
    public Pet AddPet(AddPetCommand request)
    {
        Pet p = new()
        {
            PetId = _pet.Max(x => x.PetId) + 1,
            PetName = request.PetName,
            Category = Category.Bunny,
            PetStatus = PetStatus.Available,
        };
        _pet.Add(p);
        return p;
    } 
    public Pet DeletePet(Pet pet)
    {
        _pet.Remove(pet);
        return pet;
    }
    public Pet EditPet(Pet pet)
    { 
        var pets = _pet.Find(x => x.PetId == pet.PetId);
       Pet p = new()
       {
           PetName = pet.PetName,
       };
       return pets;


    }
}