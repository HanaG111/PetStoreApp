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
        var pet = _petService.GetPets().FirstOrDefault(x => x.Status == request.Status);

        if (pet.Status is not ("Available" or "Pending"))
        {
            throw new ApplicationException("This status does not exist");
        }
        return await Task.FromResult(pet);
    }
}