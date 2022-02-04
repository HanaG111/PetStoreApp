using MediatR;
using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure;

namespace PetStoreApp.Application.Orders.Services;
public class OrderService : IOrderService
{
    private readonly IMediator _mediator;
    private readonly IOrderReadWrite _orderReadWrite;

    private readonly List<Order> _order = new();
    public OrderService(IOrderReadWrite orderReadWrite)
    {
        _orderReadWrite = orderReadWrite;
        _order.Add(new Order {OrderId = 1, PetId = 1, Quantity = 1, ShipDate = "10/11/2021", OrderStatus = OrderStatus.Placed, Complete = true});
    }
    public List<Order> GetOrders()
    {
        return _orderReadWrite.Read();
        // return _order;
    }
    public async Task<Order> CreateOrder(CreateOrderCommand request)
    {
        Order o = new()
        {
            OrderId = _order.Max(x => x.OrderId) + 1,
            PetId = request.PetId,
            Quantity = request.Quantity,
            ShipDate = "21/10/2021",
            OrderStatus = OrderStatus.Placed,
            Complete = true,
        };
        _order.Add(o);
        await _orderReadWrite.Write(o);
        return o;
    }
    public Order DeleteOrder(Order order)
    {
        var orders = GetOrders();
        _order.Remove(order);
        _orderReadWrite.Write(order);
        return order;
    }
}