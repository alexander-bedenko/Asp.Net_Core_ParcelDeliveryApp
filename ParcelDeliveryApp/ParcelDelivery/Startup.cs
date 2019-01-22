using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParcelDelivery.BLL.Infrastructure;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.BLL.Services;
using ParcelDelivery.DAL.EF;
using ParcelDelivery.DAL.Interfaces;
using ParcelDelivery.Infrastructure;

namespace ParcelDelivery
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Auto Mapper Configurations
            Mapper.Initialize(x =>
            {
                AutoMapperWebConfig.ConfigAction.Invoke(x);
                AutoMapperBllConfig.ConfigAction.Invoke(x);
            });

            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/account/login"));

            services.RegisterBllServices(Configuration);
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICarrierService, CarrierService>();
            //services.AddTransient<IParcelDeliveryContext, ParcelDeliveryContext>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddTransient<IServiceService, ServiceService>();
            //services.AddTransient<IFeedbackService, FeedbackService>();
            //services.AddTransient<IParcelDeliveryContext, ParcelDeliveryContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
