using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<OrderModel>
{
    public int OrderId { get; set; }
    public OrderModelDto OrderDto { get; set; }
}