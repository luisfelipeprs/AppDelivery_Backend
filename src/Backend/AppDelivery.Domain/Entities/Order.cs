using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int ConsumerId { get; set; }
        public Consumidor? Consumidor { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public Delivery? Delivery { get; set; }
    }

}
