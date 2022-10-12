namespace SingleDatabaseMultiTenancy.Domain.Exception
{
    public class SingleDatabaseMultiTenancyException : System.Exception
    {
        public SingleDatabaseMultiTenancyException(string message) : base(message)
        {
        }
    }
}