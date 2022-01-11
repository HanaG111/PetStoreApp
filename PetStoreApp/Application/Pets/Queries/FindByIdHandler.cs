using PetStoreApp.Domain.Models;
using PetStoreApp.Application.Queries;
using MediatR;
using PetStoreApp.Application.DataAccess;

namespace PetStoreApp.Application.Handlers;

public class FindByIdHandler : IRequestHandler<FindByIdQuery, PetModel>
{
    private readonly IDataAccess _dataAccess;

    public FindByIdHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<PetModel> Handle(FindByIdQuery request, CancellationToken cancellationToken)
    {
        var pet = _dataAccess.GetPets().FirstOrDefault(x => x.PetId == request.PetId);

        if (pet == null)
        {
            throw new ApplicationException("No Pet");
        }

        return await Task.FromResult(pet);
    }
}


