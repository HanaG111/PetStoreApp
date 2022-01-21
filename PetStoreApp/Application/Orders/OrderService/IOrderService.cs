using PetStoreApp.Domain.Models;
using PetStoreApp.Domain.Dtos;

namespace PetStoreApp.Application.Orders.OrderService;
public interface IOrderService
{
    List<OrderModel> GetOrders(); 
    OrderModel CreateOrder(int orderId, OrderModelDto orderDto);
    OrderModel DeleteOrder(OrderModel order);
}