using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.DTO
{
    public record RegisterRent(
        Guid userId,
        Guid propertyId
    );
}
