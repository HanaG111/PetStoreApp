using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Repositories;
using PetStoreApp.Domain.Constants;

namespace PetStoreApp.Application.Pets.Services;

public class PetService : IPetService
{
    private readonly IFileRepository<Pet> _fileRepository;
    private readonly List<Pet> _pet = new();

    public PetService(IFileRepository<Pet> fileRepository)
    {
        _fileRepository = fileRepository;
    }

    public List<Pet> GetPets()
    {
        return _fileRepository.GetAllAsync(FileConstants.fileName).GetAwaiter().GetResult();
    }

    public async Task<Pet> AddPet(AddPetCommand request)
    {
        Pet p = new()
        {
            PetId = GetPets().Max(x => x.PetId) + 1,
            PetName = request.PetName,
            Category = Category.Bunny,
            PetStatus = PetStatus.Available,
        };
        _pet.Add(p);
        await _fileRepository.AddAsync(p, FileConstants.fileName);
        return p;
    }

    public async Task<Pet> DeletePet(Pet pet)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        _pet.Remove(findPet);
        await _fileRepository.DeleteAsync(pet, FileConstants.fileName);
        return pet;
    }

    public async Task<Pet> EditPet(Pet pet, string petName)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        pet.PetName = petName;
        await _fileRepository.UpdateAsync(pet, petName, FileConstants.fileName);
        return pet;
    }
}