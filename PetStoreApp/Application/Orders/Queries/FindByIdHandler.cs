using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Queries;
public class FindByIdHandler : IRequestHandler<FindByIdQuery, Order>
{
    private readonly IOrderService _orderService;

    public FindByIdHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<Order> Handle(FindByIdQuery request, CancellationToken cancellationToken)
    {
        var order = _orderService.GetOrders().FirstOrDefault(x => x.OrderId == request.OrderId);

        if (order == null)
        {
            throw new ApplicationException("No Order with this Id");
        }
        return await Task.FromResult(order);
    }
}