using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Rent.Command
{
    public class RegisterPropertyValidator : AbstractValidator<RegisterRentCommand>
    {
        public RegisterPropertyValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PropertyId).NotEmpty();
        }
    }
}
