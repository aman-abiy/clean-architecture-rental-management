using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_Rental_Management.Interface
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
