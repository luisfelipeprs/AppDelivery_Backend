namespace AppDelivery.Communication.Responses;
public class ResponseLoginDriverJson
{
    public long? Id { get; set; }
    public string Role { get; set; } = "driver";
    public string Message { get; set; } = string.Empty;
}