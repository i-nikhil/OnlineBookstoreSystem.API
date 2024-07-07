namespace OnlineBookstoreSystem.API.Services;

public interface IOrderService
{
    void AddToCart(int userId, int bookId);
    void PlaceOrder(int userId);
    decimal CalculateTotalCost(int userId);
}
