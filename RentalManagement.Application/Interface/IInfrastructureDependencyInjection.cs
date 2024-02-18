using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Interface
{
    public interface IInfrastructureDependencyInjection
    {
        public IServiceCollection AddInfrastructure(
           IServiceCollection services,
           ConfigurationManager configuration
        );

        public IServiceCollection AddAuth(
          IServiceCollection services,
          ConfigurationManager configuration
       );
    }
}
