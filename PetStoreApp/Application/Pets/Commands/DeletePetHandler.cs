using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Pets.Services;

namespace PetStoreApp.Application.Pets.Commands;
public class DeletePetHandler : IRequestHandler<DeletePetCommand, Pet>
{
    private readonly IPetService _petService;
    public DeletePetHandler(IPetService petService)
    {
        _petService = petService;
    }
    public async Task<Pet> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var pet= _petService.GetPets().FirstOrDefault(x => x.PetId == request.PetId);
        
        if (pet == null)
        {
            throw new ApplicationException("No Pet");
        }

        return await Task.FromResult(await _petService.DeletePet(pet));
    }
}
