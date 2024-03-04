using ErrorOr;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Service.Authentication.Command
{
    public record RegisterUserCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>  ;
}
