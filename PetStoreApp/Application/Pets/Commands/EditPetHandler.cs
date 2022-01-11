// using MediatR;
// using PetStoreApp.Application.Commands;
// using PetStoreApp.Domain.Models;
// using PetStoreApp.Application.DataAccess;
// using PetStoreApp.Domain.Interfaces;
// using PetStoreApp.Presentation.Controllers;
//
// namespace PetStoreApp.Application.Handlers;
//
// public class EditPetHandler : IRequestHandler<EditPetCommand, PetModel>
// {
//     private readonly IDataAccess _data;
//
//     public EditPetHandler(IDataAccess data)
//     {
//         _data = data;
//     }
//     public Task<PetModel> Handle(EditPetCommand request, CancellationToken cancellationToken)
//     {
//         return Task.FromResult(_data.EditPet(request.PetName, request.Category, request.Status));
//     }
//     
// }