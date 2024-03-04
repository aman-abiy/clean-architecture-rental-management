using ErrorOr;
using MapsterMapper;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service.Property.Query
{
    public class PropertyQueryHandler : IRequestHandler<PropertyQuery, ErrorOr<IEnumerable<PropertyResult>>>
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _propertyRepository;

        public PropertyQueryHandler(IMapper mapper, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }

        public async Task<ErrorOr<IEnumerable<PropertyResult>>> Handle(PropertyQuery request, CancellationToken cancellationToken)
        {
            return (await _propertyRepository.GetProperties()).Select((p) => _mapper.Map<PropertyResult>(p)).ToList();
        }
    }
}
