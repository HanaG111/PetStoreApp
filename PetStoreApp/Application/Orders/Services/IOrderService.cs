using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Orders.Services;
public interface IOrderService
{
    List<Order> GetOrders();
    Task<Order> CreateOrder(CreateOrderCommand request);
    Task<Order> DeleteOrder(Order order);
}