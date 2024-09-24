namespace AppDelivery.Exceptions.ExceptionsBase;
public class ErrorOnValidationException : AppDeliveryException
{
    public IList<string> ErrorsMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorsMessages)
    {
        ErrorsMessages = errorsMessages;
    }
}
