namespace RentalManagement.Api.DTO.RequestDTO
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}
