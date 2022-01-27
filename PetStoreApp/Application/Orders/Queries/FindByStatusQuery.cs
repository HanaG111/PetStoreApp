using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Queries;
public class FindByStatusQuery : IRequest<Order>
{
    public string Status { get; set; }
}
