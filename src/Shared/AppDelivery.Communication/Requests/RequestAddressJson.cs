namespace AppDelivery.Communication.Requests;
public class RequestAddressJson
{
    public Guid AddressId { get; set; }
    public string Street { get; set; } = string.Empty;
    public long NumberHouse { get; set; } // número da casa
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty; // cep
    public string Country { get; set; } = string.Empty;

    public Guid DeliveryId { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid DriverId { get; set; }

}
