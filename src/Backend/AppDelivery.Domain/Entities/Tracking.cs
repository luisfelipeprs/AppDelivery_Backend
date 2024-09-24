using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDelivery.Domain.Entities
{
    public class Tracking
    {
        public int Id { get; set; }
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }
        public string CodigoRastreio { get; set; }
        public string LocalizacaoAtual { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
