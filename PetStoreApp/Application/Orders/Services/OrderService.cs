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
    }
    public List<Order> GetOrders()
    {
        return _orderReadWrite.Read();
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
    public async Task<Order> DeleteOrder(Order order)
    {
        var orders = GetOrders().Find(x => x.OrderId == order.OrderId);
        await _orderReadWrite.Remove(order);
        return order;
    }
}