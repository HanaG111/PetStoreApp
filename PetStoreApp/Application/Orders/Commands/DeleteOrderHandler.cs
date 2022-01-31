using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;

public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, Order>
{
    private readonly IOrderService _orderService;

    public DeleteOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Order> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _orderService.GetOrders().FirstOrDefault(x => x.OrderId == request.OrderId);

        if (order == null)
        {
            throw new ApplicationException("No Order with this Id");
        }

        return await Task.FromResult(_orderService.DeleteOrder(order));
    }
}