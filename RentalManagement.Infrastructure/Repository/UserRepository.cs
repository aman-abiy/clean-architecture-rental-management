using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Domain.DTO;
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

        private readonly IMapper _mapper;
        private readonly RentalManagementDbContext _dbContext;

        public UserRepository(IMapper mapper, RentalManagementDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }


        public async Task<User> AddUser(RegisterUser user)
        {
            User newUser = _mapper.Map<User>(user);
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return newUser;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.Where(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}
