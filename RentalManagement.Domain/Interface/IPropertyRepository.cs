using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Interface
{
    public interface IPropertyRepository
    {
        public Task<IEnumerable<Property>> GetProperties();
        public Task<Property?> GetPropertyByName(string name);
        public Task<Property> AddProperty(RegisterProperty registerProperty);
    }
}
