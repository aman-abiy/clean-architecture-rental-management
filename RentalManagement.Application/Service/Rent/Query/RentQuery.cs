using ErrorOr;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Rent.Query
{
    public record RentQuery(
        Guid? UserId,
        Guid? PropertyId
    ) : IRequest<ErrorOr<IEnumerable<RentResult>>>;
}
