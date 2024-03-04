using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.Api.DTO.ResponseDTO;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Service.Property.Command;
using RentalManagement.Application.Service.Property.Query;

namespace RentalManagement.Api.Controllers
{
    [Route("/property")]
    public class PropertyController : ApiController
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public PropertyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty(RegisterPropertyCommand command)
        {
            ErrorOr<PropertyResult> registerResponse = await _mediator.Send(command);

            return registerResponse.Match(
                registerResponse => Ok(
                   _mapper.Map<PropertyResponse>(registerResponse)
            ),
                errors => Problem(errors)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            ErrorOr<IEnumerable<PropertyResult>> registerResponse = await _mediator.Send(new PropertyQuery(null, null));

            return registerResponse.Match(
                registerResponse => Ok(
                   registerResponse.Select((p) => _mapper.Map<PropertyResponse>(p))
            ),
                errors => Problem(errors)
            );
        }
    }
}
