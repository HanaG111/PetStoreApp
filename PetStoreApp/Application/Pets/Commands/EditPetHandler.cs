 using MediatR;
 using PetStoreApp.Domain.Models;
 using PetStoreApp.Application.Pets.Services;

 namespace PetStoreApp.Application.Pets.Commands;
 public class EditPetHandler : IRequestHandler<EditPetCommand, Pet>
 {
     private readonly IPetService _petService;
     public EditPetHandler(IPetService petService)
     {
         _petService = petService;
     }

     public async Task<Pet> Handle(EditPetCommand request, CancellationToken cancellationToken)
     {
         var pet = _petService.GetPets().FirstOrDefault();

         if (pet.PetStatus == PetStatus.Sold)
         {
             throw new ApplicationException("Pet Sold");
         }
         if (pet.PetId == null)
         {
             throw new ApplicationException("No Pet");
         }

         return await Task.FromResult(_petService.EditPet(pet));
     }
 }