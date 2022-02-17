using MediatR;
using PetStoreApp.Application.Orders.Services;
using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure;

namespace PetStoreApp.Application.Orders.Commands;
public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    private readonly IOrderService _orderService;
    private readonly IOrderReadWrite _orderReadWrite;
    private readonly IPetService _petService;

    public CreateOrderHandler(IOrderService orderService, IPetService petService)
    {
        _orderService = orderService;
        _orderReadWrite = _orderReadWrite;
        _petService = _petService;
    }

    public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var pet = _petService.GetPets().Find(x => x.PetId == request.PetId);
        if (pet == null)
        {
            throw new ApplicationException("No Pet with this Id");
        }
        return await Task.FromResult(await _orderService.CreateOrder(request));
    }
}