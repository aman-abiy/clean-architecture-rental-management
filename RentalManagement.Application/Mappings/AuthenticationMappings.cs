using Mapster;
using RegisterHandler.Service.Authentication.Query;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Interface;
using RentalManagement.Application.Service.Rent.Command;
using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Service.Authentication.Command;

namespace RentalManagement.Api.Mappings
{
    public class AuthenticationMappingConfig : IRegister
    {
      

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Property, PropertyResult>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.UpdatededDateTime, src => src.UpdatededDateTime)
                .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime);

            config.NewConfig<RegisterRentCommand, RegisterRent>()
                .Map(dest => dest.userId, src => Guid.Parse(src.UserId))
                .Map(dest => dest.propertyId, src => Guid.Parse(src.PropertyId));

            config.NewConfig<Rent, RentResult>()
    .Map(dest => dest.User, src => src.user)
    .Map(dest => dest.Property, src => src.property)
    .Map(dest => dest.UpdatededDateTime, src => src.UpdatededDateTime)
    .Map(dest => dest.CreatedDateTime, src => src.CreatedDateTime);

        }
    }
}
