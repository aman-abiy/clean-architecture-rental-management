using Microsoft.EntityFrameworkCore;
using RentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Infrastructure.Context
{
    public class RentalManagementDbContext : DbContext
    {

        public RentalManagementDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.user)
                .WithMany() // Specify the navigation property in the User entity if there is one
                .HasForeignKey(r => r.userId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Or .Restrict based on your requirements

            modelBuilder.Entity<Rent>()
                .HasOne(r => r.property)
                .WithMany() // Specify the navigation property in the Property entity if there is one
                .HasForeignKey(r => r.propertyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict); // Adjust based on your needs


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Rent> Rents { get; set; }
    }
}
