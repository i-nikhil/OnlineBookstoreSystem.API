namespace OnlineBookstoreSystem.API.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<Book> Books { get; set; }
    public decimal TotalCost { get; set; }
    public DateTime OrderDate { get; set; }
}
