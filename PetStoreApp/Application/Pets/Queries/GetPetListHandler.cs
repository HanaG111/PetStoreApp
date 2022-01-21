using PetStoreApp.Application.Pets.DataAccess;
using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Queries;
public class GetPetListHandler : IRequestHandler<GetPetListQuery, List<PetModel>>
{
    private readonly IDataAccess _dataAccess;
    public GetPetListHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public Task<List<PetModel>> Handle(GetPetListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_dataAccess.GetPets());
    }
}

