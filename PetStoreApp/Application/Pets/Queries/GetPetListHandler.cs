using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class GetPetListHandler : IRequestHandler<GetPetListQuery, List<Pet>>
{
    private readonly IPetService _petService;
    public GetPetListHandler(IPetService petService)
    {
        _petService = petService;
    }
    public Task<List<Pet>> Handle(GetPetListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_petService.GetPets());
    }
}

