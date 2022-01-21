using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.DataAccess;
public class DataAccess : IDataAccess
{
    private readonly IMediator _mediator;

    private readonly List<PetModel> _pet = new();
    public DataAccess()
    {
        _pet.Add(new PetModel {PetId = 1, PetName = "Ice", Category = "Dog", Status = "Available"});
        _pet.Add(new PetModel {PetId = 2, PetName = "Donna", Category = "Cat", Status = "Pending"});
        _pet.Add(new PetModel {PetId = 3, PetName = "Max", Category = "Dog", Status = "Available"});
    }
    public List<PetModel> GetPets()
    {
        return _pet;
    }
    public PetModel AddPet(int petId, PetModelDto petDto)
    {
        PetModel p = new()
        {
            PetId = _pet.Max(x => x.PetId) + 1,
            PetName = petDto.PetName,
            Category = petDto.Category,
            Status = petDto.Status,
        };
        return p;
    }
    public PetModel DeletePet(PetModel pet)
    {
         var pets = GetPets();
          pets.Remove(pet);
          return pet;
    }
    public PetModel EditPet(int petId, PetModelDto petDto)
    {
        PetModel p = new()
        {
            PetName = petDto.PetName,
            Category = petDto.Category,
            Status = petDto.Status,
        };
        return p;
    }
}