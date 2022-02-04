using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;

public class CreateOrderCommand : IRequest<Order>
{
    public int PetId { get; set; }
    public int Quantity { get; set; }
    public string ShipDate { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public bool Complete { get; set; }
}