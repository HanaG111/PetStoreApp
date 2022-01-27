using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;
public class DeleteOrderCommand : IRequest<Order>
{
    public int OrderId { get; set; }
    public OrderDto OrderDto { get; set; }
}