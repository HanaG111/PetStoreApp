using PetStoreApp.Application.Pets.DataAccess;
using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Pets.Commands;
public class AddPetHandler : IRequestHandler<AddPetCommand, PetModel>
{
    private readonly IDataAccess _dataAccess;
    public AddPetHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }
    public async Task<PetModel> Handle(AddPetCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_dataAccess.AddPet(request.PetName, request.Category, request.Status));
    }
}

