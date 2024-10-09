namespace AppDelivery.Communication.Responses;
public class ResponseLoginConsumerJson
{
    public Guid? Id { get; set; }
    public string Role { get; set; } = "consumer";
    public string Message { get; set; } = string.Empty;
}