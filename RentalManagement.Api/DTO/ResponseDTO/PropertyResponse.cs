using RentalManagement.Domain.Entities;

namespace RentalManagement.Api.DTO.ResponseDTO
{
    public record PropertyResponse(
        string Name,
        string Description,
        DateTime UpdatededDateTime,
        DateTime CreatedDateTime
    );
}
