using PetStoreApp.Application.Commands;
using PetStoreApp.Application.DataAccess;
using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Handlers;

public class AddPetHandler : IRequestHandler<AddPetCommand, PetModel>
{
    private readonly IDataAccess _data;
    public AddPetHandler(IDataAccess data)
    {
        _data = data;
    }

    public async Task<PetModel> Handle(AddPetCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_data.AddPet(request.PetName, request.Category, request.Status));
    }
}

