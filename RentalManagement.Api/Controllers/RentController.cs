using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentalManagement.Api.DTO.RequestDTO.Body;
using RentalManagement.Api.DTO.RequestDTO.Param;
using RentalManagement.Api.DTO.ResponseDTO;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Service.Rent.Command;
using RentalManagement.Application.Service.Rent.Query;

namespace RentalManagement.Api.Controllers
{
    [Route("/rent")]
    public class RentController : ApiController
    {
        private readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public RentController(IMediator mediator, IMapper mapper) { 
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRent(RegisterRent registerRent)
        {

            RegisterRentCommand command = _mapper.Map<RegisterRentCommand>(registerRent);

            ErrorOr<RentResponse> rentResponse = _mapper.Map<RentResponse>(await _mediator.Send(new RegisterRentCommand(registerRent.userId, registerRent.propertyId)));

            return rentResponse.Match(
                rentResponse => Ok(
                   _mapper.Map<RentResponse>(rentResponse)
            ),
                errors => Problem(errors)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetRent([FromQuery] RentParam rentParam)
        {

            ErrorOr<IEnumerable<RentResult>> rentResult = await _mediator.Send(_mapper.Map<RentQuery>(rentParam));

            return rentResult.Match(
                rentResult => Ok(
                   rentResult.Select((e) => _mapper.Map<RentResponse>(e))
            ),
                errors => Problem(errors)
            );
       }
    }
}
