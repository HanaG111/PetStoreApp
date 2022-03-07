using PetStoreApp.Domain.Models;


namespace PetStoreApp.Domain.Factories;

public class PetFactory
{
    public void FindPet(int petId, string petName, Category category, petStatus petStatus)
    {
        Pets = new List<Pet>
        {
            PetId = _petService().Max(x => x.PetId) + 1,
            PetName = PetName,
            Category = Category,
            PetStatus = PetStatus,
        };
    }
}