namespace OnlineBookstoreSystem.API.Exceptions
{
    public class EmptyCartException : Exception
    {
        public EmptyCartException(string message) : base(message)
        {
        }
    }
}
