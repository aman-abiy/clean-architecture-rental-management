using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Entities
{
    public class Rent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid userId { get; set; }

        [Required]
        public User user { get; set; } = null!;

        [Required]
        public Guid propertyId { get; set; }

        [Required]
        public Property property { get; set; } = null!;

        public DateTime UpdatededDateTime { get; set; } = DateTime.Now;

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
