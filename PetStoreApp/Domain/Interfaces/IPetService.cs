using PetStoreApp.Presentation.Controllers;
using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Services;


namespace PetStoreApp.Domain.Interfaces;

public interface IPetService : IDisposable
{
    Task<IEnumerable<Pet>> GetPets();
    Task<Pet> FindById(int petId);
    Task<Pet> FindByStatus(string status);
    
    Task<Pet> AddPet(Pet petModel);
    Task<Pet> EditPet(Pet pet);
    Task<bool> DeletePet(Pet pet);
    
 



}