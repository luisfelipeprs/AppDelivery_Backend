namespace AppDelivery.Communication.Requests;
public class RequestResetPasswordJson
{
    public string TypeEntity { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}