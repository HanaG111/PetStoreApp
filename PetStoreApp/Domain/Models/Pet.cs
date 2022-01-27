namespace PetStoreApp.Domain.Models;
public class Pet : Entity
{
    public string PetName { get; set; }
    public string Category { get; set; } 
    public string Status { get; set; }
}