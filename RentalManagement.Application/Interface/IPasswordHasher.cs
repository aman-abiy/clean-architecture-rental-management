using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Interface
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
        public bool Compare(string password, string hashedValue);
    }
}
