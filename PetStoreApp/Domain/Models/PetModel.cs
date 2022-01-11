
namespace PetStoreApp.Domain.Models;

public class PetModel : Entity
{
    public string PetName { get; set; }
    public string Category { get; set; } 
    public string Status { get; set; }
}