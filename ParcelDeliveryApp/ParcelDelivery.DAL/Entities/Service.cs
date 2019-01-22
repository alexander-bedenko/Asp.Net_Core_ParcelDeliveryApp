
using ParcelDelivery.DAL.Enums;

namespace ParcelDelivery.DAL.Entities
{
    public class Service : BaseEntity
    {
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public float MaxWeight { get; set; }
        public decimal Coast { get; set; }
        public TypeOfCargo TypeOfCargo { get; set; }
        public TransportationArea TransportationArea { get; set; }
    }
}
