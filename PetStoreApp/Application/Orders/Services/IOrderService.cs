using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Orders.Services;
public interface IOrderService
{
    List<Order> GetOrders(); 
    Task<Order> CreateOrder(CreateOrderCommand request);
    Order DeleteOrder(Order order);
}