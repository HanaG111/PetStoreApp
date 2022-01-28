using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IMediator _mediator;

    private readonly List<Pet> _pet = new();
    public PetService()
    {
        _pet.Add(new Pet {PetId = 1, PetName = "Ice", Category = "Dog", Status = "Available"});
        _pet.Add(new Pet {PetId = 2, PetName = "Donna", Category = "Cat", Status = "Pending"});
        _pet.Add(new Pet {PetId = 3, PetName = "Max", Category = "Dog", Status = "Available"});
    }
    public List<Pet> GetPets()
    {
        return _pet;
    }
    public Pet AddPet(PetDto petDto)
    {
        Pet p = new()
        {
            PetId = _pet.Max(x => x.PetId) + 1,
            PetName = petDto.PetName,
            Category = petDto.Category,
            Status = petDto.Status,
        };
        return p;
    } 
    public Pet DeletePet(Pet pet)
    {
        var pets = GetPets();
        pets.Remove(pet);
        return pet;
    }
    public Pet EditPet(Pet pet)
    {
       /* var pets = GetPets();
        Pet p = new()
        {
            PetName = pet.PetName,
        };
        return p
       */
       var pets = _pet.Find(x => x.PetId == pet.PetId);
       pets.

    }
}