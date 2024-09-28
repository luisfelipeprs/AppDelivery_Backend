using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Domain.Entities
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; } = string.Empty;

        // Relacionamento com o entregador
        public int DeliveryPersonId { get; set; }
        public Driver? Driver { get; set; }

        // Relacionamento com o pedido
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }

}
