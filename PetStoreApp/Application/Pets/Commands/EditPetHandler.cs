﻿ using MediatR;
 using PetStoreApp.Domain.Models;
 using PetStoreApp.Application.Pets.DataAccess;

 namespace PetStoreApp.Application.Pets.Commands;

 public class EditPetHandler : IRequestHandler<EditPetCommand, PetModel>
 {
     private readonly IDataAccess _dataAccess;

     public EditPetHandler(IDataAccess dataAccess)
     {
         _dataAccess = dataAccess;
     }
     public Task<PetModel> Handle(EditPetCommand request, CancellationToken cancellationToken)
     {
         var pet = _dataAccess.GetPets().FirstOrDefault(x => x.PetId == request.PetId);

         if (pet.PetId != request.PetId)
         {
             throw new ApplicationException("No Pet");
         }
         return Task.FromResult(_dataAccess.EditPet(request.PetName, request.Category, request.Status));
     }

 }