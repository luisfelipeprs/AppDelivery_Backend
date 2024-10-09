using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Communication.Responses;
public class ResponseDriverJson
{
    public Guid Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Cnh { get; set; } = string.Empty;
    public string Vehicle { get; set; } = string.Empty;
    public string DocumentationVehicle { get; set; } = string.Empty;
    public string TypeDriver { get; set; } = string.Empty;

    public Guid? CompanyId { get; set; }
}
