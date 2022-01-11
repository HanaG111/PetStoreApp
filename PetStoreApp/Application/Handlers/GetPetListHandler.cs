using PetStoreApp.Application.DataAccess;
using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Queries;
using MediatR;


namespace PetStoreApp.Application.Handlers;

public class GetPetListHandler : IRequestHandler<GetPetListQuery, List<PetModel>>
{
    private readonly IDataAccess _data;

    public GetPetListHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<List<PetModel>> Handle(GetPetListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.GetPets());
    }
}

