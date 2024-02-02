using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Application.Services;
using DesafioAutoGlass.Domain.Core.Interfaces.Repositories;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Core.Notifications;
using DesafioAutoGlass.Domain.Service;
using DesafioAutoGlass.Infrastructure.Data;
using DesafioAutoGlass.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioAutoGlass.Infrastructure.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // APPLICATION
            services.AddScoped<IApplicationProductServices, ApplicationProductServices>();
            services.AddScoped<IApplicationSupplierServices, ApplicationSupplierServices>();

            // DOMAIN SERVICE
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();

            // DOMAIN REPOSITORY
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<INotifier, Notifier>();

            //INFRA
            services.AddScoped<SqlDbContext>();
        }
    }
}