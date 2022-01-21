using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.OrderService;
public class OrderService : IOrderService
{
    private readonly IMediator _mediator;

    private readonly List<OrderModel> _order = new();

    public OrderService()
    {
        _order.Add(new OrderModel {OrderId = 1, PetId = 1, Quantity = 1, ShipDate = "10/11/2021", Status = "Placed", Complete = true});
    }
    public List<OrderModel> GetOrders()
    {
        return _order;
    }
    public OrderModel CreateOrder(int orderId, OrderModelDto orderDto)
    {
        OrderModel o = new()
        {
            OrderId = _order.Max(x => x.OrderId) + 1,
            PetId = orderDto.PetId,
            Quantity = orderDto.Quantity,
            ShipDate = orderDto.ShipDate,
            Status = orderDto.Status,
            Complete = orderDto.Complete
        };
        return o;
    }
    public OrderModel DeleteOrder(OrderModel order)
    {
        var orders = GetOrders();
        orders.Remove(order);
        return order;
    }
}