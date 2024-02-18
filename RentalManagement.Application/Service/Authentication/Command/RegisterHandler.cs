using Clean_Architecture_Rental_Management.Interface;
using MediatR;
using RentalManagement.Domain.Interface;
using RentalManagement.DTO;
using RentalManagement.Service.Authentication.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Service.Authentication.Command
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        public readonly IUserRepository _userRepository;
        public readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            if()
        }
    }
}
