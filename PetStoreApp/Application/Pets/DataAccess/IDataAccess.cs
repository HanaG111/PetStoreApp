using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.DataAccess
{
    public interface IDataAccess
    {
        List<PetModel> GetPets();
        PetModel AddPet(string petName, string category, string status);
    }
}