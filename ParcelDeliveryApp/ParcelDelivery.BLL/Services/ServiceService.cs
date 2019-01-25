using System;
using System.Collections.Generic;
using System.Linq;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Extensions;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;
using TransportationArea = ParcelDelivery.DAL.Enums.TransportationArea;
using TypeOfCargo = ParcelDelivery.DAL.Enums.TypeOfCargo;

namespace ParcelDelivery.BLL.Services
{
    public class ServiceService : CrudService<Service, ServiceDto>, IServiceService
    {
        public ServiceService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<FilteredListDto> FilteredList(ServiceDto serviceDto)
        {
            var listOfCarriers = new List<FilteredListDto>();
            var services = _uow.Repository<Service>().GetAll();
            var filteredList = _uow.Repository<Service>().GetAll()
                .Where(toc => toc.TypeOfCargo.Equals((TypeOfCargo)serviceDto.TypeOfCargo))
                .Where(ta => ta.TransportationArea.Equals((TransportationArea)serviceDto.TransportationArea))
                .Where(w => w.MaxWeight >= serviceDto.MaxWeight)
                .Select(c => c.CarrierId).ToList();

            foreach (var key in filteredList)
            {
                listOfCarriers.Add(new FilteredListDto()
                {
                    CarrierId = _uow.Repository<Carrier>().Get(x => x.Id == key).Id,
                    Name = _uow.Repository<Carrier>().Get(x => x.Id == key).Name,
                    Address = _uow.Repository<Carrier>().Get(x => x.Id == key).Address,
                    Phone = _uow.Repository<Carrier>().Get(x => x.Id == key).Phone,
                    Description = _uow.Repository<Carrier>().Get(x => x.Id == key).Description,
                    Coast = _uow.Repository<Service>().Get(p => p.CarrierId == key).Coast * (decimal)serviceDto.Distance,
                    Type = _uow.Repository<Service>().Get(p => p.CarrierId == key)?.TransportationArea.GetDisplayName(),
                    Time = TimeInTransit(
                        serviceDto.Distance,
                        _uow.Repository<Service>().Get(p => p.CarrierId == key).TransportationArea.GetDisplayName())
                });
            }

            return listOfCarriers;
        }

        private double TimeInTransit(double distance, string type)
        {
            double time = 0;

            switch (type)
            {
                case "City":
                    time = distance / 17;
                    break;

                case "Region":
                    time = distance / 53;
                    break;

                case "Country":
                    time = distance / 70;
                    break;

                case "International":
                    time = distance / 90;
                    break;
            }

            return Math.Round(time, 2);
        }
    }
}
