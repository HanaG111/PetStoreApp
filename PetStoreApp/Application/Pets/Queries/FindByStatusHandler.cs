using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Pets.Services;

namespace PetStoreApp.Application.Pets.Queries;

public class FindByStatusHandler : IRequestHandler<FindByStatusQuery, Pet>
{
    private readonly IPetService _petService;

    public FindByStatusHandler(IPetService petService)
    {
        _petService = petService;
    }

    public async Task<Pet> Handle(FindByStatusQuery request, CancellationToken cancellationToken)
    {
        var pet = _petService.GetPets().Find(x => x.PetStatus == request.PetStatus);
        if (pet.PetStatus != PetStatus.Available)
        {
            throw new ApplicationException("This status does not exist");
        }

        return await Task.FromResult(pet);
    }
}