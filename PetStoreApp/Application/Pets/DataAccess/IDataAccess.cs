using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.DataAccess
{ 
    public interface IDataAccess
    { 
        List<PetModel> GetPets();
        PetModel AddPet(string petName, string category, string status);
        PetModel DeletePet(int petId);
        PetModel EditPet(string petName, string category, string status);
    }
}