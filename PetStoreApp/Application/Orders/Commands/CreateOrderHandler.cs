using MediatR;
using PetStoreApp.Application.Orders.OrderService;
using PetStoreApp.Application.Pets.DataAccess;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderModel>
{
    private readonly IDataAccess _dataAccess;
    private readonly IOrderService _orderService;
    public CreateOrderHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<OrderModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var pet = _orderService.GetOrders().FirstOrDefault(x => x.PetId == request.OrderDto.PetId);

        if (pet == null)
        {
            throw new ApplicationException("No Pet with this Id");
        }
        
        return await Task.FromResult(_orderService.CreateOrder(request.OrderId, request.OrderDto));
    }
}