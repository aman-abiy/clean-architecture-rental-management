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
        public string userId { get; set; } = null!;

        [Required]
        public User user { get; set; } = null!;

        [Required]
        public string propertyId { get; set; } = null!;

        [Required]
        public User property { get; set; } = null!;

        public DateTime UpdatededDateTime { get; set; } = DateTime.Now;

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
