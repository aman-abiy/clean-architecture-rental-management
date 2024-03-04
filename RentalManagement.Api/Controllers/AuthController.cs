using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegisterHandler.Service.Authentication.Query;
using RentalManagement.Api.DTO.RequestDTO.Body;
using RentalManagement.Api.DTO.ResponseDTO;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Service.Authentication.Command;

namespace RentalManagement.Api.Controllers
{
    [Route("auth")]
    public class AuthController : ApiController
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper) {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            RegisterUserCommand command = _mapper.Map<RegisterUserCommand>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(
                    _mapper.Map<AuthenticationResponse>(authResult)
            ),
                errors => Problem(errors)
            );
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginQuery query = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            return authResult.Match(
                authResult => Ok(
                    _mapper.Map<AuthenticationResponse>(authResult)
            ),
                errors => Problem(errors)
            );
        }
    }
}
