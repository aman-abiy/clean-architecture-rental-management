using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using RentalManagement.Interface;
using System.Reflection;

namespace RentalManagement.Application.Mappings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
            // register the mapper as Singleton service for my application
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);

            return services;
        }
    }
}
