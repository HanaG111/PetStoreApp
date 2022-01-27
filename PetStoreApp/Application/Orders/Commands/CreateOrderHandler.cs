using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IPetService _petService;
    private readonly IOrderService _orderService;
    public CreateOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        
        return await Task.FromResult(_orderService.CreateOrder(request));
    }
}

