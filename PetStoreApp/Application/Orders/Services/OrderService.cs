using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Services;
public class OrderService : IOrderService
{
    private readonly IMediator _mediator;

    private readonly List<Order> _order = new();

    public OrderService()
    {
        _order.Add(new Order {OrderId = 1, PetId = 1, Quantity = 1, ShipDate = "10/11/2021", Status = "Placed", Complete = true});
    }
    public List<Order> GetOrders()
    {
        return _order;
    }

    public Order CreateOrder(OrderDto orderDto)
    {
        Order o = new()
        {
            OrderId = _order.Max(x => x.OrderId) + 1,
            PetId = orderDto.PetId,
            Quantity = orderDto.Quantity,
            ShipDate = "21/10/2021",
            Status = "shiped",
            Complete = true,

        };
        _order.Orders.Add(o);
         var success = _orderService.SaveChangesAsync() > 0;
         if (success) return Order.Value;
    }
    }

    public Order DeleteOrder(Order order)
    {
        var orders = GetOrders();
        orders.Remove(order);
        return order;
    }
}