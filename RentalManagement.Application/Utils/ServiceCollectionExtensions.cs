using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Utils
{
    public static class ServiceCollectionExtensions
    {
        // This method acts as a bridge to the IInfrastructureDependencyInjection implementation.
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            IInfrastructureDependencyInjection implementation = new InfrastructureDependencyInjectionImpl();
            return implementation.AddInfrastructure(services, configuration);
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            IInfrastructureDependencyInjection implementation = new InfrastructureDependencyInjectionImpl();
            return implementation.AddAuth(services, configuration);
        }
    }
}
