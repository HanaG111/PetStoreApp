using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderService _orderService;
    public CreateOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var pet= _orderService.GetOrders().Find(x => x.PetId == request.PetId);

        if (Order.PetId == null)
        {
            throw new ApplicationException("No Pet with this Id");
        }
        return await Task.FromResult(_orderService.CreateOrder(request));
    }
}

