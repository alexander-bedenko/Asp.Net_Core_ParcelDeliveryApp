using System;
using System.Linq.Expressions;
using AutoMapper;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.DAL.Entities;

namespace ParcelDelivery.BLL.Infrastructure
{
    public static class AutoMapperBllConfig
    {
        public static readonly Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            cfg.CreateMap<UserDto, User>().ReverseMap();
            cfg.CreateMap<CarrierDto, Carrier>().ReverseMap();
            cfg.CreateMap<ServiceDto, Service>().ReverseMap();
            cfg.CreateMap<FeedbackDto, Feedback>().ReverseMap();
        };
    }
}
