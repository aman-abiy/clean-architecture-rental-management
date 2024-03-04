using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Interface
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(UserDTO user);
    }
}
