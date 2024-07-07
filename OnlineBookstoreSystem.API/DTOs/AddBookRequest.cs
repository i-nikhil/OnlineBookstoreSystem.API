namespace OnlineBookstoreSystem.API.DTOs;

public class AddBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
