using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Interface
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByEmail(string email);

        public Task<User> AddUser(RegisterUser user);
    }
}
