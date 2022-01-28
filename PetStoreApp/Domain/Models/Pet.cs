namespace PetStoreApp.Domain.Models;
public class Pet : Entity
{
    public string PetName { get; set; }
    public enum Category 
    {  
        Dog, 
        Cat, 
        Bunny 
    }
    public enum Status
    {
        Available,
        Pending,
        Sold
    }
       
    /* 
     public IsAvailable(string status)
     {
         if (this.status == "Available")
             return true;
     }
     
  
     
     IsAvailable 
         IsPending
     IsSold
         
         GetPet to check if pet exists
    */
}