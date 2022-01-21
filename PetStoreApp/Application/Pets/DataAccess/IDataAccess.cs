using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Pets.DataAccess;
    public interface IDataAccess
    { 
        List<PetModel> GetPets(); 
        PetModel DeletePet(PetModel pet);
        PetModel AddPet(int petId, PetModelDto petDto);
        PetModel EditPet(int petId, PetModelDto petDto);
    }
