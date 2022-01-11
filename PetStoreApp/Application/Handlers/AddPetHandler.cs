using PetStoreApp.Application.Commands;
using PetStoreApp.Application.DataAccess;
using PetStoreApp.Domain.Models;
using MediatR;
using PetStoreApp.Application.Handlers;

namespace PetStoreApp.Application.Handlers;

public class AddPetHandler : IRequestHandler<AddPetCommand, PetModel>
{
    private readonly IDataAccess _data;

    public AddPetHandler(IDataAccess data)
    {
        _data = data;
    }

    public Task<PetModel> Handle(AddPetCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_data.AddPet(request.PetName, request.Category, request.Status));
    }
}

