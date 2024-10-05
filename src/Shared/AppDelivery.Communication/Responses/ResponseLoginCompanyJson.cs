namespace AppDelivery.Communication.Responses;
public class ResponseLoginCompanyJson
{
    public long? Id { get; set; }
    public string Role { get; } = "company";
    public string Message { get; set; } = string.Empty;
}