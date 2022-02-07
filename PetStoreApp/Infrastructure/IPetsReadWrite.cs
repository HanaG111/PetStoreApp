using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;
public interface IPetsReadWrite 
{
        Task Write(Pet pet);
        List<Pet> Read(); 
        Task Remove(Pet pet);
        Task Edit(Pet pet, string petName);
}