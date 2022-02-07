using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;
public interface IOrderReadWrite 
{
        Task Write(Order order);
        List<Order> Read(); 
        
}