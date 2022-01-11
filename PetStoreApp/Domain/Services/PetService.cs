using PetStoreApp.Domain.Interfaces;
using PetStoreApp.Domain.Models;
using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Domain.Services;

public class PetService : IPetService
{
    private readonly IPetRepository _petRepository;

    public PetService(IPetRepository petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<Pet>> GetPets()
    {
        return await _petRepository.GetPets();
    }

    public async Task<Pet> FindById(int petId)
    {
        return await _petRepository.FindById(petId);
    }

    public async Task<Pet> AddPet(Pet pet)
    {

        await _petRepository.AddPet(pet);
        return pet;
    }

    public async Task<Pet> EditPet(Pet pet)
    {

        await _petRepository.EditPet(pet);
        return pet;
    }

    public async Task<bool> DeletePet(Pet pet)
    {
        var pe
        await _petRepository.DeletePet(pet);
        return true;
    }
    
    public async Task<IEnumerable<Pet>> FindByStatus(string status)
    {
        await _petRepository.FindByStatus(status);
        return true;
    }
    
    public void Dispose()
    {
        _petRepository?.Dispose();
    }

}