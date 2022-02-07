namespace PetStoreApp.Domain.Models;
public class Pet : Entity
{
    public string PetName { get; set; }
    public Category Category { get; set; }
    public PetStatus PetStatus { get; set; }

    public bool IsAvailable()
    {
        return PetStatus == PetStatus.Available;
    }
    public bool IsPending()
    {
        return PetStatus == PetStatus.Pending;
    }
    public bool IsSold()
    {
        return PetStatus == PetStatus.Sold;
    }
}
public enum Category
{
    Dog = 0,
    Cat = 1,
    Bunny = 2
}
public enum PetStatus
{
   Available = 0,
   Pending = 1,
   Sold = 2
}
