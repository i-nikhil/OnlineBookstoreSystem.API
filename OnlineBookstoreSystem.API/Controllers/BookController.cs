using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreSystem.API.DTOs;
using OnlineBookstoreSystem.API.Exceptions;
using OnlineBookstoreSystem.API.Models;
using OnlineBookstoreSystem.API.Services;

namespace OnlineBookstoreSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    /// <summary>
    /// Dependency injecting service layer
    /// </summary>
    /// <param name="bookService"></param>
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Add new book to the store
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="InvalidPriceException"></exception>
    /// <exception cref="InvalidStockException"></exception>
    [HttpPost]
    public IActionResult AddBook(AddBookRequest request)
    {
        if (request.Price <= 0)
        {
            throw new InvalidPriceException("Price of book should be greater than 0.");
        }

        if(request.Stock <=0)
        {
            throw new InvalidStockException("Number of books should be greater than 0.");
        }

        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Price = request.Price,
            Stock = request.Stock
        };
        _bookService.AddBook(book);
        return Ok();
    }

    /// <summary>
    /// Get list of boks available in the store
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }
}
