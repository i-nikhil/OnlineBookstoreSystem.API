using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Services;

public interface IBookService
{
    void AddBook(Book book);
    IEnumerable<Book> GetAllBooks();
}
