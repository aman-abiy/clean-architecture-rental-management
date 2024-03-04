using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Interface;
using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Domain.Interface;
using RentalManagement.Infrastructure.DTO;
using RentalManagement.Interface;
using RentalManagement.Service.Authentication.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Service.Authentication.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByEmail(command.Email) is not null)
            {
                // throw error
            }


            RegisterUser user = _mapper.Map<RegisterUser>(command);

            user.Password = _passwordHasher.Hash(command.Password);


            UserDTO newUser = _mapper.Map<UserDTO>(await _userRepository.AddUser(user));

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthenticationResult(newUser, token);

        }
    }
}
