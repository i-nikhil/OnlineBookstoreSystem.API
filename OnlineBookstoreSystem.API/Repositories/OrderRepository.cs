using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new List<Order>();

    public void AddOrder(Order order)
    {
        order.Id = _orders.Count + 1;
        _orders.Add(order);
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _orders;
    }

    public Order GetOrderById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id);
    }
}
