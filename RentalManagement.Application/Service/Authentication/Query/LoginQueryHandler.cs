using ErrorOr;
using MapsterMapper;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Interface;
using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Domain.Interface;
using RentalManagement.Infrastructure.DTO;
using RentalManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterHandler.Service.Authentication.Query
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public readonly IMapper _mapper;
        public readonly IUserRepository _userRepository;
        public readonly IPasswordHasher _passwordHasher;
        public readonly IJwtTokenGenerator _jwtTokenGenerator;


        public LoginQueryHandler(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetUserByEmail(query.Email);

            if (user is null)
            {
                return Error.NotFound("User not found!");
            }

            bool status = _passwordHasher.Compare(query.Password, user!.Password);

            if(!status)
            {
                return Error.Unauthorized("Password is incorrect!");
            }

            UserDTO newUser = _mapper.Map<UserDTO>(user);

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthenticationResult(newUser, token);
        }
    }
}
