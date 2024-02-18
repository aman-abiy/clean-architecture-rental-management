using Clean_Architecture_Rental_Management.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RentalManagement.Domain.Interface;
using RentalManagement.Infrastructure.Authentication;
using RentalManagement.Infrastructure.Context;
using RentalManagement.Infrastructure.DTO;
using RentalManagement.Infrastructure.Repository;
using RentalManagement.Infrastructure.Utils;
using RentalManagement.Interface;
using System.Text;

namespace RentalManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           ConfigurationManager configuration
        )
        {
            services.AddAuth(configuration);
            services.AddDatabase(configuration);
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        public static IServiceCollection AddAuth(
           this IServiceCollection services,
           ConfigurationManager configuration
        )
        {
            // bind JwtSettings object with JwtSettings in appsettings.json
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);
            services.AddSingleton(Options.Create(jwtSettings));

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration[jwtSettings.Issuer],
                    ValidAudience = configuration[jwtSettings.Audience],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret
                    ))
                });

            return services;
        }

        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            ConfigurationManager configuration
         )
        {
            services.AddDbContext<RentalManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
