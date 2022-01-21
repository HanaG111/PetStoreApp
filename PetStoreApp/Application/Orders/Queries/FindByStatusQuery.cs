using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Queries;
public class FindByStatusQuery : IRequest<OrderModel>
{
    public string Status { get; set; }
}
