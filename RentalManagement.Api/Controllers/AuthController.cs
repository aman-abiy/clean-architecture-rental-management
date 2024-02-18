using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.Api.DTO.RequestDTO;
using RentalManagement.DTO;
using RentalManagement.Service.Authentication.Command;

namespace RentalManagement.Api.Controllers
{
    [Route("/auth")]
    public class AuthController : ControllerBase
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
            RegisterCommand command = _mapper.Map<RegisterCommand>(request);

            AuthenticationResult authResult = await _mediator.Send(command);

            return Ok(authResult);
        }
    }
}
