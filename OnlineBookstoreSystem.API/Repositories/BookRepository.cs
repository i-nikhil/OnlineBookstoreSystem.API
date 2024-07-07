using OnlineBookstoreSystem.API.Models;

namespace OnlineBookstoreSystem.API.Repositories;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void UpdateBook(Book book)
    {
        var existingBook = GetBookById(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.Stock = book.Stock;
        }
    }
}
