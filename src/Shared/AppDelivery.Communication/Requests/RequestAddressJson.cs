namespace AppDelivery.Communication.Requests;
public class RequestAddressJson
{
    public long AddressId { get; set; }
    public string Street { get; set; } = string.Empty;
    public long NumberHouse { get; set; } // número da casa
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty; // cep
    public string Country { get; set; } = string.Empty;

    public long DeliveryId { get; set; }
    public long CompanyId { get; set; }
    public long DriverId { get; set; }

}
