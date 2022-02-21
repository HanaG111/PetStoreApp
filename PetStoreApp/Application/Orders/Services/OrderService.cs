using PetStoreApp.Application.Orders.Commands;
using PetStoreApp.Domain.Constants;
using PetStoreApp.Domain.Models;
using PetStoreApp.Infrastructure.Repositories;

namespace PetStoreApp.Application.Orders.Services;
public class OrderService : IOrderService
{
    private readonly IFileRepository<Order> _fileRepository;
    private readonly List<Order> _order = new();
    public OrderService(IFileRepository<Order> fileRepository)
    {
        _fileRepository = fileRepository;
    }
    public List<Order> GetOrders()
    {
        return _fileRepository.GetAllAsync(FileConstants.orderFile).GetAwaiter().GetResult();
    }
    public async Task<Order> CreateOrder(CreateOrderCommand request)
    {
        Order o = new()
        {
            OrderId = GetOrders().Max(x => x.OrderId) + 1,
            PetId = request.PetId,
            Quantity = request.Quantity,
            ShipDate = "21/10/2021",
            OrderStatus = OrderStatus.Placed,
            Complete = true,
        };
        _order.Add(o);
        await _fileRepository.AddAsync(o, FileConstants.orderFile);
        return o;
    }
    public async Task<Order> DeleteOrder(Order order)
    {
        var orders = GetOrders().Find(x => x.OrderId == order.OrderId);
        _order.Remove(order);
        await _fileRepository.DeleteAsync(order, FileConstants.orderFile);
        return order;
    }
}