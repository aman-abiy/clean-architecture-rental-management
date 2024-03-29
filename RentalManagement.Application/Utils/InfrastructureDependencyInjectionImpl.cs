﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Utils
{

    // This class is acting as extension implemetation to convert convert the IInfrastructureDependencyInjection interface to a static method
    // in the ServiceCollectionExtention so that we can call it statically in program.cs, since the presentation layer is not associated with
    // the Infrastructure layer. This implementation is bridging that separation of concern
    public class InfrastructureDependencyInjectionImpl : IInfrastructureDependencyInjection
    {
        public IServiceCollection AddInfrastructure(IServiceCollection services, ConfigurationManager configuration)
        {
            // Actual implementation code here.
            return services;
        }

        public IServiceCollection AddAuth(IServiceCollection services, ConfigurationManager configuration)
        {
            // Actual implementation code here.
            return services;
        }
    }
}
