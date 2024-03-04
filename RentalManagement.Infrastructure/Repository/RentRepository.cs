using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Application.Service.Rent.Query;
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
    public class RentRepository : IRentRepository
    {
        private readonly IMapper _mapper;
        private readonly RentalManagementDbContext _dbContext;

        public RentRepository(IMapper mapper, RentalManagementDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Rent> AddRent(RegisterRent registerRent)
        {
            Rent rent = _mapper.Map<Rent>(registerRent);
            await _dbContext.Rents.AddAsync(rent);
            await _dbContext.SaveChangesAsync();
            rent = await _dbContext.Rents
               .Include(r => r.user) // Replace with your actual navigation property
               .Include(r => r.property) // Replace with your second navigation property
               .FirstOrDefaultAsync(r => r.Id == rent.Id);

            return rent;
        }

        public async Task<List<Rent>> GetRents(GetRent getRent)
        {

            IQueryable<Rent> rentsQuery = _dbContext.Rents;


            if (getRent.UserId is not null)
            {
                rentsQuery = rentsQuery.Where(r => r.userId == getRent.UserId);
            }

            if (getRent.PropertyId is not null)
            {
                rentsQuery = rentsQuery.Where(r => r.propertyId == getRent.PropertyId);
            }

            rentsQuery = rentsQuery.Include(p => p.user);
            rentsQuery = rentsQuery.Include(p => p.property);

            return await rentsQuery.ToListAsync();


            // return await _dbContext.Rents.Include((p) => p.user).Include((p) => p.property).ToListAsync();
        }

    }
}
