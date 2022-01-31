using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Queries;

public class FindByIdQuery : IRequest<Order>
{
    public int OrderId { get; set; }
}