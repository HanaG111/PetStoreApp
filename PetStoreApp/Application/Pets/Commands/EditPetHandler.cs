using MediatR;
using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Pets.Services;

namespace PetStoreApp.Application.Pets.Commands;

public class EditPetHandler : IRequestHandler<EditPetCommand, Pet>
{
    private readonly IPetService _petService;

    public EditPetHandler(IPetService petService)
    {
        _petService = petService;
    }

    public async Task<Pet> Handle(EditPetCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(await _petService.EditPet(request));
    }
}