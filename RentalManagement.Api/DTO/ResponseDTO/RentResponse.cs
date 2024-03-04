using RentalManagement.Domain.Entities;

namespace RentalManagement.Api.DTO.ResponseDTO
{
    public record RentResponse(
        User User,
        Property Property,
        DateTime UpdatededDateTime,
        DateTime CreatedDateTime
    );
}
