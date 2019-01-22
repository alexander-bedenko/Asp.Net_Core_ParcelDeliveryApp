using System;
using AutoMapper;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.Models;

namespace ParcelDelivery.Infrastructure
{
    public class AutoMapperWebConfig : Profile
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, UserViewModel>().ReverseMap();
            cfg.CreateMap<CarrierDto, CarrierViewModel>().ReverseMap();
            cfg.CreateMap<ServiceDto, PropertyViewModel>().ReverseMap();
            cfg.CreateMap<FeedbackDto, FeedbackViewModel>().ReverseMap();
        };
    }
}
