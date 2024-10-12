namespace AppDelivery.Communication.Responses;
public class ResponseLoginConsumerJson
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Consumer";
    public string Message { get; set; } = string.Empty;
}