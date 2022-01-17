using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.DataAccess
{ 
    public interface IDataAccess
    { 
        List<PetModel> GetPets();
        PetModel AddPet(string petName, string category, string status);
        PetModel DeletePet(PetModel pet);
        PetModel EditPet(PetModel pet);
    }
}