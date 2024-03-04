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
    internal class PropertyRepository : IPropertyRepository
    {
        private readonly IMapper _mapper;
        private readonly RentalManagementDbContext _dbContext;

        public PropertyRepository(IMapper mapper, RentalManagementDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Property> AddProperty(RegisterProperty registerProperty)
        {
            Property property = _mapper.Map<Property>(registerProperty);

            await _dbContext.Properties.AddAsync(property);
            await _dbContext.SaveChangesAsync();

            return property;
        }

        public async Task<IEnumerable<Property>> GetProperties()
        {
            var k = await _dbContext.Properties.ToListAsync();
            return await _dbContext.Properties.ToListAsync();

        }

        public async Task<Property?> GetPropertyByName(string name)
        {
            return await _dbContext.Properties.SingleOrDefaultAsync((p) => p.Name == name);
        }
    }
}
