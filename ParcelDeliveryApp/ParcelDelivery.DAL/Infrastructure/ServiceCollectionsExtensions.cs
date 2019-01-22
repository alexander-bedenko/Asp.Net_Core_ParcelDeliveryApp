using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.DAL.EF;
using ParcelDelivery.DAL.Interfaces;
using ParcelDelivery.DAL.Repositories;

namespace ParcelDelivery.DAL.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(DbContext), typeof(ParcelDeliveryContext));
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ParcelDeliveryContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

            return services;
        }
    }
}
