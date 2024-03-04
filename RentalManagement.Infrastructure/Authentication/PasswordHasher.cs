using RentalManagement.Application.Interface;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.Authentication
{
    internal class PasswordHasher : IPasswordHasher
    {
        public bool Compare(string password, string hashedValue)
        {
            bool check = BCrypt.Net.BCrypt.Verify(password, hashedValue);
            return check;
        }

        public string Hash(string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
    }
}
