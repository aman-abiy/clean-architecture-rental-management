using Microsoft.AspNetCore.Mvc.Infrastructure;
using RentalManagement.Api.Mappings;

namespace RentalManagement.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();
            return services;
        }
    }
}
