using RentalManagement.Domain.Entities;
using RentalManagement.Domain.Interface;
using RentalManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.Repository
{
    internal class UserRepository : IUserRepository
    {

        private readonly RentalManagementDbContext _dbContext;

        public UserRepository(RentalManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser()
        {
            
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Us
        }
    }
}
