using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Factories;
using PetStoreApp.Infrastructure.Repositories;
using PetStoreApp.Domain.Constants;

namespace PetStoreApp.Application.Pets.Services;

public class PetService : IPetService
{
    private readonly IFileRepository<Pet> _fileRepository;
    private readonly PetFactory _petFactory;
    private readonly List<Pet> _pet = new();

    public PetService(IFileRepository<Pet> fileRepository, PetFactory petFactory)
    {
        _fileRepository = fileRepository;
        _petFactory = petFactory;
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
        //_pet.Add(p);
        await _fileRepository.AddAsync(p, FileConstants.fileName).ConfigureAwait(false);
        return p;
    }

    public async Task<Pet> DeletePet(Pet pet)
    {
        //_pet.Find(x => x.PetId == pet.PetId);
        //_pet.Remove(pet);
        await _fileRepository.DeleteAsync(pet, FileConstants.fileName).ConfigureAwait(false);
        return pet;
    }

    public async Task<Pet> EditPet(EditPetCommand request)
    {
        var pet = _petFactory.GetPets().Find(x => x.PetId == request.PetId);
        if (pet == null)
        {
            throw new ApplicationException("No Pet");
        }

        //var findPet = _pet.Find(x => x.PetId == pet.PetId);
        pet.PetName = petName;
        await _fileRepository.UpdateAsync(pet, petName, FileConstants.fileName).ConfigureAwait(false);
        return pet;
    }
}