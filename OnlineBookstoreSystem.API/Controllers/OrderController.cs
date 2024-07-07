using Microsoft.AspNetCore.Mvc;
using OnlineBookstoreSystem.API.DTOs;
using OnlineBookstoreSystem.API.Services;

namespace OnlineBookstoreSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    /// <summary>
    /// Dependency injecting service layer
    /// </summary>
    /// <param name="orderService"></param>
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Add a book to user's cart
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-to-cart")]
    public IActionResult AddToCart(AddToCartRequest request)
    {
        _orderService.AddToCart(request.UserId, request.BookId);
        return Ok();
    }

    /// <summary>
    /// Place order for books in user's cart
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("place-order/{userId}")]
    public IActionResult PlaceOrder(int userId)
    {
        _orderService.PlaceOrder(userId);
        return Ok();
    }

    /// <summary>
    /// Calulate total bill payable by user
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("total-cost/{userId}")]
    public IActionResult CalculateTotalCost(int userId)
    {
        var totalCost = _orderService.CalculateTotalCost(userId);
        return Ok(totalCost);
    }
}
