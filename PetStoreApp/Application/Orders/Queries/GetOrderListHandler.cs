using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Orders.Queries;
public class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<Order>>
{
    private readonly IOrderService _orderService;

    public GetOrderListHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public Task<List<Order>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_orderService.GetOrders());
    }
}
