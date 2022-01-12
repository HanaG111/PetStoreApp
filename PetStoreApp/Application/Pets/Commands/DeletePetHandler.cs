using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Pets.DataAccess;


namespace PetStoreApp.Application.Pets.Commands;

public class DeletePetHandler : IRequestHandler<DeletePetCommand, PetModel>
{
    private readonly IDataAccess _dataAccess;

    public DeletePetHandler(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<PetModel> Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_dataAccess.DeletePet(request.PetId));
    }
}
