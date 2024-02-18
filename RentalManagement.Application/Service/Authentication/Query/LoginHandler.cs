using Clean_Architecture_Rental_Management.Interface;
using MediatR;
using RentalManagement.Domain.Interface;
using RentalManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterHandler.Service.Authentication.Query
{
    public class LoginHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        public readonly IUserRepository _userRepository;
        public readonly IJwtTokenGenerator _jwtTokenGenerator;


        public LoginHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
