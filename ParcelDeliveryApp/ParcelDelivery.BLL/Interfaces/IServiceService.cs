using System.Collections.Generic;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.BLL.Interfaces
{
    public interface IServiceService : ICrudService<Service, ServiceDto>
    {
        IEnumerable<FilteredListDto> FilteredList(ServiceDto serviceDto);
    }
}