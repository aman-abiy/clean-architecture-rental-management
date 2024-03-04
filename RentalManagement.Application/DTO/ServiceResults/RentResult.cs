using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.DTO.ServiceResults
{
    public record RentResult(
        User User,
        Property Property,
        DateTime UpdatededDateTime,
        DateTime CreatedDateTime
    );
}
