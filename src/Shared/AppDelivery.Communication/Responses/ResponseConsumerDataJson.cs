namespace AppDelivery.Communication.Responses;
public class ResponseConsumerDataJson
{
    public Guid Id { get; set; }
    public bool Active { get; set; } = true;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}