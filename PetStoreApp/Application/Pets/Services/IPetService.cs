using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Services;
    public interface IPetService
    { 
        List<Pet> GetPets(); 
        Pet DeletePet(Pet pet);
        Pet AddPet(AddPetCommand request);
        Pet EditPet(Pet pet, string petName);
    }
