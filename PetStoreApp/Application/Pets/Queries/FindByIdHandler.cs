using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Pets.Services;

namespace PetStoreApp.Application.Pets.Queries;

public class FindByIdHandler : IRequestHandler<FindByIdQuery, Pet>
{
    private readonly IPetService _petService;

    public FindByIdHandler(IPetService petService)
    {
        _petService = petService;
    }

    public async Task<Pet> Handle(FindByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = _petService.GetPets().FirstOrDefault(x => x.PetId == request.PetId);
        if (pet == null)
        {
            throw new ApplicationException("No Pet");
        }

        return await Task.FromResult(pet);
    }
}


