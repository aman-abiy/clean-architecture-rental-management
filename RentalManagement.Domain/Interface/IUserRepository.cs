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
        public User GetUserByEmail(string email);

        public User AddUser();
    }
}
