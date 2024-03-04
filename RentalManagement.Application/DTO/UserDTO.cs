using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.DTO
{
    public record UserDTO(
        string Id,
        string FirstName,
        string LastName,
        string Email,
        DateTime UpdatededDateTime,
        DateTime CreatedDateTime
    );
}
