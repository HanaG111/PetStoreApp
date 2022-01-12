using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Pets.DataAccess;

namespace PetStoreApp.Application.Pets.Queries;

public class FindByStatusHandler : IRequestHandler<FindByStatusQuery, PetModel>
{
    private readonly IDataAccess _dataAccess;

    public FindByStatusHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<PetModel> Handle(FindByStatusQuery request, CancellationToken cancellationToken)
    {
        var pet = _dataAccess.GetPets().FirstOrDefault(x => x.Status == request.Status);

        if (pet.Status is not ("Available" or "Pending"))
        {
            throw new ApplicationException("This status does not exist");
        }
        return await Task.FromResult(pet);
    }
}