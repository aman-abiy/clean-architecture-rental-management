using MediatR;
using RentalManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterHandler.Service.Authentication.Query
{
    public record LoginQuery(
        string Email,
        string Password
    ) : IRequest<AuthenticationResult>;
}
