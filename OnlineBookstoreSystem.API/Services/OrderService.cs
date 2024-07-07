using OnlineBookstoreSystem.API.Exceptions;
using OnlineBookstoreSystem.API.Models;
using OnlineBookstoreSystem.API.Repositories;

namespace OnlineBookstoreSystem.API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;

    private readonly Dictionary<int, List<int>> shoppingCarts = new();

    public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository, IUserRepository userRepository)
    {
        _orderRepository = orderRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
    }

    public void AddToCart(int userId, int bookId)
    {
        if(_userRepository.GetUserById(userId) == null)
        {
            throw new UserNotFoundException($"The user with id {userId} does not exist.");
        }

        if (_bookRepository.GetBookById(bookId) == null)
        {
            throw new BookNotFoundException($"The book with id {bookId} does not exist.");
        }

        if (!shoppingCarts.ContainsKey(userId))
        {
            shoppingCarts[userId] = new List<int>();
        }
        shoppingCarts[userId].Add(bookId);
    }

    public void PlaceOrder(int userId)
    {
        if (_userRepository.GetUserById(userId) == null)
        {
            throw new UserNotFoundException($"The user with id {userId} does not exist.");
        }

        if (!shoppingCarts.ContainsKey(userId))
        {
            throw new EmptyCartException("No items in the cart.");
        }

        var order = new Order
        {
            UserId = userId,
            Books = new List<Book>(),
            OrderDate = DateTime.UtcNow
        };

        foreach (var bookId in shoppingCarts[userId])
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && book.Stock > 0)
            {
                order.Books.Add(book);
                book.Stock--;
                _bookRepository.UpdateBook(book);
            }
        }

        order.TotalCost = CalculateTotalCost(userId);
        _orderRepository.AddOrder(order);

        shoppingCarts[userId].Clear();
    }

    public decimal CalculateTotalCost(int userId)
    {
        if (_userRepository.GetUserById(userId) == null)
        {
            throw new UserNotFoundException($"The user with id {userId} does not exist.");
        }

        decimal totalCost = 0;

        if (shoppingCarts.ContainsKey(userId))
        {
            foreach (var bookId in shoppingCarts[userId])
            {
                var book = _bookRepository.GetBookById(bookId);
                if (book != null)
                {
                    totalCost += book.Price;
                }
            }
        }

        return totalCost;
    }
}
