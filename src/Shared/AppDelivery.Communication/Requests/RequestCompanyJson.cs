namespace AppDelivery.Communication.Requests;
public class RequestCompanyJson
{
    public long Id { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string Cep { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string NumberLocation { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}
