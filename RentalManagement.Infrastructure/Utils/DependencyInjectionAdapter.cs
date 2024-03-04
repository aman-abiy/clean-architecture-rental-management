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
    // THis is an adapter class that bridges the static class of the DependencyInjection to implement the IInfrastructureDependencyInjection
    // interface in the application layer, since static classes can not implement interfaces
    public class DependencyInjectionAdapter : IInfrastructureDependencyInjection
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
