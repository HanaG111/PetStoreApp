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
        var pet= _dataAccess.GetPets().FirstOrDefault(x => x.PetId == request.PetId);

        if (pet == null)
        {
            throw new ApplicationException("No Pet");
        }

        return await Task.FromResult(_dataAccess.DeletePet(pet));
    }
}
