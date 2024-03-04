using ErrorOr;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
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
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}
