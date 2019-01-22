using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Services
{
    public class CarrierService : CrudService<Carrier, CarrierDto>, ICarrierService
    {
        public CarrierService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
