namespace PetStoreApp.Domain.Models;
public class Order : OrderEntity
{
    public int PetId { get; set; }
    public int Quantity { get; set; }
    public string ShipDate { get; set; }
    public bool Complete { get; set; }
    public OrderStatus OrderStatus { get; set; }
    private bool IsPlaced()
    {
        return OrderStatus == OrderStatus.Placed;
    }
    private bool IsProcessing()
    {
        return OrderStatus == OrderStatus.Processing;
    }
    private bool IsShipped()
    {
        return OrderStatus == OrderStatus.Shipped;
    }
    private bool IsComplete()
    {
        return OrderStatus == OrderStatus.Shipped;
    }
}
public enum OrderStatus
{
    Placed,
    Processing,
    Shipped
}

