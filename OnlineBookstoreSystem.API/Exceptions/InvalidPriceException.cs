namespace OnlineBookstoreSystem.API.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message)
        {
        }
    }
}
