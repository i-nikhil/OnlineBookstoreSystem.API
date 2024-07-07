namespace OnlineBookstoreSystem.API.Exceptions
{
    public class InvalidStockException : Exception
    {
        public InvalidStockException(string message) : base(message)
        {
        }
    }
}
