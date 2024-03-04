namespace RentalManagement.Api.DTO.RequestDTO.Body
{
    public record RegisterRent(
        string userId,
        string propertyId
    );
}
