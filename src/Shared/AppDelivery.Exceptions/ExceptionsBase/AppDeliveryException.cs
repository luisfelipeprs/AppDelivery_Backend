namespace AppDelivery.Exception.ExceptionBase;
public abstract class AppDeliveryException : SystemException
{
    protected AppDeliveryException(string message) : base(message)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
