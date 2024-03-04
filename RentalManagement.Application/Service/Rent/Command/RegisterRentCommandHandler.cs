using ErrorOr;
using MapsterMapper;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Rent.Command
{
    public class RegisterRentCommandHandler : IRequestHandler<RegisterRentCommand, ErrorOr<RentResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRentRepository _rentRepository;

        public RegisterRentCommandHandler(IMapper mapper, IRentRepository rentRepository)
        {
            _mapper = mapper;
            _rentRepository = rentRepository;
        }

        public async Task<ErrorOr<RentResult>> Handle(RegisterRentCommand command, CancellationToken cancellationToken)
        {
            RegisterRent rent = _mapper.Map<RegisterRent>(command);

            return _mapper.Map<RentResult>(await _rentRepository.AddRent(rent));
        }
    }
}
