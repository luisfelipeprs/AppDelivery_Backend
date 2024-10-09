namespace AppDelivery.Communication.Responses;
public class ResponseReviewJson
{
    public Guid Id { get; set; }
    public Guid ConsumerId { get; set; }
    public int Rating { get; set; } 
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}