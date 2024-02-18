using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.Utils
{
    // THis is an adapter class that bridges tha static class of the DependencyInjection ti implement the IInfrastructureDependencyInjection
    // interface in the application layer, since static classes can not implement interfaces
    internal class DependencyInjectionAdapter : IInfrastructureDependencyInjection
    {
        public IServiceCollection AddInfrastructure(IServiceCollection services, ConfigurationManager configuration)
        {
            return DependencyInjection.AddInfrastructure(services, configuration);
        }

        public IServiceCollection AddAuth(IServiceCollection services, ConfigurationManager configuration)
        {
            return DependencyInjection.AddAuth(services, configuration);
        }
    }
}
