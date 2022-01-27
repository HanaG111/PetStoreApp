using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Commands;
public class CreateOrderCommand : IRequest<Order>
{
    public int petId { get; set; }
    public int quantity { get; set; }
    public string shipDate { get; set; }
    public enum status { get; set; }

    public bool complete { get; set; }
    
}