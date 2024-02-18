using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.DTO
{
    public record AuthenticationResult(
        User user,
        string token
    );
}
