using ErrorOr;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Property.Query
{
    public record PropertyQuery(
        string? Name,
        string? Description
    ) : IRequest<ErrorOr<IEnumerable<PropertyResult>>>;
}
