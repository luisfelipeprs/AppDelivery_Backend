namespace AppDelivery.Communication.Responses;
public enum DriverType
{
    Car = 0,
    Motorcycle = 1,
}

public class ResponseDriverDataJson
{
    public Guid Id { get; set; }
    public bool Active { get; set; } = true;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string Cnh { get; set; } = string.Empty;
    public string Vehicle { get; set; } = string.Empty;
    public string DocumentationVehicle { get; set; } = string.Empty;

    public Guid? CompanyId { get; set; }
    public DriverType DriverType { get; set; }
}
