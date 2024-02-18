using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Entities
{
    public class Property
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        [Required(ErrorMessage = "Property Name is a required field!")]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime UpdatededDateTime { get; set; } = DateTime.Now;

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
