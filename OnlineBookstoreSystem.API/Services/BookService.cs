using OnlineBookstoreSystem.API.Models;
using OnlineBookstoreSystem.API.Repositories;

namespace OnlineBookstoreSystem.API.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void AddBook(Book book)
    {
        _bookRepository.AddBook(book);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _bookRepository.GetAllBooks();
    }
}
