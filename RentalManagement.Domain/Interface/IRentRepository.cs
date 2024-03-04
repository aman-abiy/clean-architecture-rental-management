using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Interface
{
    public interface IRentRepository
    {
        public Task<List<Rent>> GetRents(GetRent getRent);

        public Task<Rent> AddRent(RegisterRent registerRent);
    }
}
