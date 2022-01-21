using MediatR;
using PetStoreApp.Application.Orders.OrderService;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Queries;

public class FindByStatusHandler : IRequestHandler<FindByStatusQuery, OrderModel>
{
    private readonly IOrderService _orderService;
    
    public FindByStatusHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    public async Task<OrderModel> Handle(FindByStatusQuery request, CancellationToken cancellationToken)
    {
        var order = _orderService.GetOrders().FirstOrDefault(x => x.Status == request.Status);

        if (order.Status is not ("Placed" or "Unplaced"))
        {
            throw new ApplicationException("This status does not exist");
        }
        return await Task.FromResult(order);
    }
}