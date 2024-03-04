namespace RentalManagement.Api.DTO.RequestDTO.Body
{
    public record LoginRequest(
        string Email,
        string Password
    );
}
