using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.DTO.ServiceResults
{
    public record AuthenticationResult(
        UserDTO User,
        string Token
    );
}
