using FluentValidation;
using RentalManagement.Application.Service.Property.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Properties.Command
{
    public class RegisterPropertyValidator : AbstractValidator<RegisterPropertyCommand>
    {
        public RegisterPropertyValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
