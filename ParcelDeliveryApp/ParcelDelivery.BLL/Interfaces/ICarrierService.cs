using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.BLL.Interfaces
{
    public interface ICarrierService : ICrudService<Carrier, CarrierDto>
    {
    }
}