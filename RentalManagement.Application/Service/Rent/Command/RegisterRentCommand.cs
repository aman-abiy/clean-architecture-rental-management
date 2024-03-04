using ErrorOr;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Rent.Command
{
    public record RegisterRentCommand(
        string UserId,
        string PropertyId
    ) : IRequest<ErrorOr<RentResult>>;
}
