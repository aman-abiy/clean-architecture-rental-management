using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(100)]
        [Required(ErrorMessage = "First Name is a required field!")]
        public string FirstName { get; set; } = null!;
        
        [MaxLength(100)]
        [Required(ErrorMessage = "Last Name is a required field!")]
        public string LastName { get; set;} = null!;

        [MaxLength(100)]
        [Required(ErrorMessage = "Email is a required field!")]
        public string Email { get; set; } = null!;

        [MaxLength(200)]
        [Required(ErrorMessage = "Password is a required field!")]
        public string Password { get; set; } = null!;

        public DateTime UpdatededDateTime { get; set; } = DateTime.Now;

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
