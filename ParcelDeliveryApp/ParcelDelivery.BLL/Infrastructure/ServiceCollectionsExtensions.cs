using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.DAL.EF;
using ParcelDelivery.DAL.Infrastructure;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddScoped<IParcelDeliveryContext, ParcelDeliveryContext>();

            return services;
        }
    }
}
