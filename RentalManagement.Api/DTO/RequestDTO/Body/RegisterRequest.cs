namespace RentalManagement.Api.DTO.RequestDTO.Body
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}
