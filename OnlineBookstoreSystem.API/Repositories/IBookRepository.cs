using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public interface IBookRepository
{
    void AddBook(Book book);
    IEnumerable<Book> GetAllBooks();
    Book GetBookById(int id);
    void UpdateBook(Book book);
}
