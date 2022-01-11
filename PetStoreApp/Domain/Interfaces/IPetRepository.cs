using PetStoreApp.Domain.Models;
using PetStoreApp.Presentation.Controllers;

namespace PetStoreApp.Domain.Interfaces;

public interface IPetRepository : IRepository<PetModel>
{
    new Task<List<Pet>> GetPets();
    new Task<Pet> FindById(int petId);
    new Task<IEnumerable<Pet>> FindByStatus(string status);
}