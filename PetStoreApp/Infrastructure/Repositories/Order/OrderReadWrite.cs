using System.Text.Json;
using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;

public class OrderReadWrite : IOrderReadWrite
{
    private readonly IOrderService _orderService;
    private readonly IMediator _mediator;

    public List<Order> Read()
    {
        List<Order> orders = new List<Order>();
        var text = File.ReadAllText("DbOrders.txt");
        orders = JsonSerializer.Deserialize<List<Order>>(text);
        return orders;
    }

    public async Task Write(Order order)
    {
        if (File.ReadAllText("DbOrders.txt").Length == 0)
        {
            List<Order> orders = new List<Order>();
            orders.Add(order);
            string json = JsonSerializer.Serialize(orders);
            await File.WriteAllTextAsync("DbOrders.txt", json);
        }
        else
        {
            List<Order> orders = Read();
            orders.Add(order);
            string json = JsonSerializer.Serialize(orders);
            await File.WriteAllTextAsync("DbOrders.txt", json);
        }
    }

    public async Task Remove(Order order)
    {
        List<Order> orders = Read();
        orders.RemoveAll(x => x.OrderId == order.OrderId);
        string json = JsonSerializer.Serialize(orders);
        await File.WriteAllTextAsync("DbOrders.txt", json);
    }
}
