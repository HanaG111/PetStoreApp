using MediatR;
using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Services;
public class OrderService : IOrderService
{
    private readonly IMediator _mediator;

    private readonly List<Order> _order = new();
    public OrderService()
    {
        _order.Add(new Order {OrderId = 1, PetId = 1, Quantity = 1, ShipDate = "10/11/2021", OrderStatus = OrderStatus.Placed, Complete = true});
    }
    public List<Order> GetOrders()
    {
        return _order;
    }
    public Order CreateOrder(CreateOrderCommand request)
    {
        var orders = GetOrders();
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
        return o;
    }
    public Order DeleteOrder(Order order)
    {
        var orders = GetOrders();
        _order.Remove(order);
        return order;
    }
}