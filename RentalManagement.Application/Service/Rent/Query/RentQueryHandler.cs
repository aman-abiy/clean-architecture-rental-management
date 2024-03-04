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

namespace RentalManagement.Application.Service.Rent.Query
{
    public class RentQueryHandler : IRequestHandler<RentQuery, ErrorOr<IEnumerable<RentResult>>>
    {
        private readonly IMapper _mapper;
        private readonly IRentRepository _repository;

        public RentQueryHandler(IMapper mapper, IRentRepository rentRepository) { 
            _mapper = mapper;
            _repository = rentRepository;
        }


        public async Task<ErrorOr<IEnumerable<RentResult>>> Handle(RentQuery request, CancellationToken cancellationToken)
        {
            return (await _repository.GetRents(_mapper.Map<GetRent>(request))).Select((r) => _mapper.Map<RentResult>(r)).ToList(); 
        }
    }
}
