using Microsoft.EntityFrameworkCore;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.Context
{
    internal class RentalManagementDbContext : DbContext
    {

        public RentalManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
