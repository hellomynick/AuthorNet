namespace YourAPI.ApiIntergration
{
    public class ApiException : Exception
    {
        public ApiException()
        {

        }
        public ApiException(string message)
        {

        }
        public ApiException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
