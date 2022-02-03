using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;
public interface IFileReadWrite 
{
        Task Write(Pet pet);
        List<Pet> Read(); 
}