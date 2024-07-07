using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public interface IOrderRepository
{
    void AddOrder(Order order);
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int id);
}
