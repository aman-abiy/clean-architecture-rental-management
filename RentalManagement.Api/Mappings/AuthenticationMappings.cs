using Mapster;
using RegisterHandler.Service.Authentication.Query;
using RentalManagement.Api.DTO.RequestDTO.Body;
using RentalManagement.Api.DTO.RequestDTO.Param;
using RentalManagement.Api.DTO.ResponseDTO;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Service.Rent.Query;

namespace RentalManagement.Api.Mappings
{
    public class AuthenticationMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);

            config.NewConfig<RentParam, RentQuery>()
                .Map(dest => dest.UserId, src => !string.IsNullOrEmpty(src.UserId) ? Guid.Parse(src.UserId) : (Guid?)null)
                .Map(dest => dest.PropertyId, src => !string.IsNullOrEmpty(src.PropertyId) ? Guid.Parse(src.PropertyId) : (Guid?)null);
        }
    }
}
