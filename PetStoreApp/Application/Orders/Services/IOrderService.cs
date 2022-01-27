using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Orders.Services;
public interface IOrderService
{
    List<Order> GetOrders(); 
    Order CreateOrder(OrderDto orderDto);
    Order DeleteOrder(Order order);
}