namespace AppDelivery.Communication.Responses;
public class ResponseConsumerDataJson
{
    public long Id { get; set; }
    public bool Active { get; set; } = true;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}