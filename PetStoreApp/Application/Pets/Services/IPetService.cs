using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.Services;
    public interface IPetService
    { 
        List<Pet> GetPets(); 
        Pet DeletePet(Pet pet);
        Pet AddPet(int petId, PetDto petDto);
        Pet EditPet(int petId, PetDto petDto);
    }
