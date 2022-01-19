 using MediatR;
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
     public async Task<PetModel> Handle(EditPetCommand request, CancellationToken cancellationToken)
     {
         var pet = _dataAccess.GetPets().FirstOrDefault(x => x.PetId == request.PetId);

         if (pet == null)
         {
             throw new ApplicationException("No Pet");
         }
         return await Task.FromResult(_dataAccess.EditPet(request.PetId, request.Pet));
     }

 }