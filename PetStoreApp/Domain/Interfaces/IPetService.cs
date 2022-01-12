using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Domain.Interfaces;

public interface IPetService : IDisposable
{
    Task<Pet> GetPets();
    Task<Pet> FindById(int petId);
    Task<Pet> FindByStatus(string status);
    Task<Pet> AddPet(Pet petModel);
    Task<Pet> EditPet(Pet pet);
    Task<bool> DeletePet(Pet pet);
}