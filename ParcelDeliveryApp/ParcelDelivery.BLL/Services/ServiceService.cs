using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Services
{
    public class ServiceService : CrudService<Service, ServiceDto>, IServiceService
    {
        public ServiceService(IUnitOfWork uow)
            : base(uow)
        {
        }
    }
}
