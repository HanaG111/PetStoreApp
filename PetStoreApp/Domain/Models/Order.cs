namespace PetStoreApp.Domain.Models;

public class Order : OrderEntity
{
    public int PetId { get; set; }
    public int Quantity { get; set; }
    public string ShipDate { get; set; }
    public enum Status
    {
        Placed,
        Processing,
        Shipped
    }
    public bool Complete { get; set; }
    
    /*IsPlaced
        IsProcessing
    IsShipped
    
        GetPet (To check if pet exists)
         */   
}