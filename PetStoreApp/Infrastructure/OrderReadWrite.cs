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
        
        // await File.WriteAllTextAsync("DbOrders.txt", json);
        //
        // var lines = System.IO.File.ReadAllLines("DbOrders.txt");

        // orders = lines.ToList<Order>();
        // foreach (var line in lines)
        // {
        //     Console.WriteLine("\t" + line);
        // }
        // Console.WriteLine("Press any key to exit.");
        // System.Console.ReadKey();
        return orders;
    }
    public async Task Write(Order order)
    {
        List<Order> orders= new List<Order>();
        orders.Add(order);

        string json = JsonSerializer.Serialize(orders);
        // List<String> orderobj= new List<String>();
        // orderobj.Add(json);

        await File.WriteAllTextAsync("DbOrders.txt", json);

        // await File.AppendAllLinesAsync("DbOrders.txt", orders);
    }
}
