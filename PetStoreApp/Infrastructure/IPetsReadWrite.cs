using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;
public interface IPetsReadWrite 
{
        Task Write(Pet pet);
        List<Pet> Read(); 
}