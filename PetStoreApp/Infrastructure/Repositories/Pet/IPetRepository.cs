using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure.Repositories.Pet;
public interface IPetRepository
{
        Task Write(Pet pet);
        List<Pet> Read();
        Task Remove(Pet pet);
        Task Edit(Pet pet, string petName);
}