using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.DTO.ServiceResults
{
    public record PropertyResult(
        string Name,
        string Description,
        DateTime UpdatededDateTime,
        DateTime CreatedDateTime
    );
}
