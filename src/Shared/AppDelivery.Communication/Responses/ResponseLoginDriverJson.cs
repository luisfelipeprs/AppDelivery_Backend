namespace AppDelivery.Communication.Responses;
public class ResponseLoginDriverJson
{
    public Guid? Id { get; set; }
    public string Role { get; set; } = "driver";
    public string Message { get; set; } = string.Empty;
}