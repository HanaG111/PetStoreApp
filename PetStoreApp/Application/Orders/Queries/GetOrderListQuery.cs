using PetStoreApp.Domain.Models;
using MediatR;

namespace PetStoreApp.Application.Orders.Queries;
public class GetOrderListQuery : IRequest<List<Order>>
{
}
    
