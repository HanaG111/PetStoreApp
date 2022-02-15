using MediatR;
using PetStoreApp.Application.Pets.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Repositories;

namespace PetStoreApp.Application.Pets.Services;
public class PetService : IPetService
{
    private readonly IMediator _mediator;
    private readonly IPetRepository<Pet> _petRepository;

    private readonly List<Pet> _pet = new();
    public PetService(IPetRepository<Pet> petRepository)
    {
        _petRepository = petRepository;
    }
    public List<Pet> GetPets()
    {
        return _petRepository.GetAllAsync();
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
        await _petRepository.AddAsync(p);
        return p;
    }
    public async Task<Pet> DeletePet(Pet pet)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        await _petRepository.DeleteAsync(pet);
        return pet;
    }
    public async Task<Pet> EditPet(Pet pet, string petName)
    {
        var findPet = _pet.Find(x => x.PetId == pet.PetId);
        pet.PetName = petName;
        await _petRepository.UpdateAsync(pet, petName);
        return pet;
    }
}