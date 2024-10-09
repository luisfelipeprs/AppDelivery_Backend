namespace AppDelivery.Communication.Responses;
public class ResponseLoginCompanyJson
{
    public Guid? Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty; 
    public string Email { get; set; } = string.Empty;
    public string Role { get; } = "company";
    public string Message { get; set; } = string.Empty;
}