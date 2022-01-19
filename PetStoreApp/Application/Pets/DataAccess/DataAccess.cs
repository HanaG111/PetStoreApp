using MediatR;
using PetStoreApp.Application.Pets.Queries;
using PetStoreApp.Application.Pets.Commands;
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
    public PetModel EditPet(int petId, PetModel pet)
    {
        var existPet = _mediator.Send(new FindByIdQuery
        {
            PetId = pet.PetId
        });

        if (existPet == null)
        {
            throw new ApplicationException($"No Pet");
        }
        
        PetModel p = new()
        {
            PetId = _pet.Max(x => x.PetId),
            PetName = pet.PetName,
            Category = pet.Category,
            Status = pet.Status,
        };

        var result = _mediator.Send(new EditPetCommand
        {
            PetId = petId,
            Pet = pet
        });
        _pet.Add(p);
        return p;
    }

    /*
      public PetModel EditPet(string petName, string category, string status)
      {
          var pets = GetPets();
          
          var existPet = await _mediator.Send(new FindByIdQuery
          {
              PetId = pet.PetId
          });
          
          pets.Find( pet => pet.PetId() ==);
         
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
  */
}