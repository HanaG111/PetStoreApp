using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Pets.Commands;
public class AddPetHandler : IRequestHandler<AddPetCommand, Pet>
{
    private readonly IPetService _petService;
    public AddPetHandler(IPetService petService)
    {
        _petService = petService;
    }
    
    public async Task<Pet> Handle(AddPetCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_petService.AddPet(request));
    
    }
}

