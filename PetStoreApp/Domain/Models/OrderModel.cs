namespace PetStoreApp.Domain.Models;
public class OrderModel : OrderEntity
{
    public int PetId { get; set; }
    public int Quantity { get; set; }
    public string ShipDate { get; set; }
    public string Status { get; set; }
    public bool Complete { get; set; }
}