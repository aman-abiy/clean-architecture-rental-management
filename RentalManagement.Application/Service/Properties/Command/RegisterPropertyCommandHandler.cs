using ErrorOr;
using MapsterMapper;
using MediatR;
using RentalManagement.Application.DTO.ServiceResults;
using RentalManagement.Application.Service.Property.Command;
using RentalManagement.Domain.DTO;
using RentalManagement.Domain.Entities;
using RentalManagement.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagement.Application.Service
{
    public class RegisterPropertyCommandHandler : IRequestHandler<RegisterPropertyCommand, ErrorOr<PropertyResult>>
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepository _propertyRepository;

        public RegisterPropertyCommandHandler(IMapper mapper, IPropertyRepository propertyRepository)
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;
        }

        public async Task<ErrorOr<PropertyResult>> Handle(RegisterPropertyCommand command, CancellationToken cancellationToken)
        {
            if(await _propertyRepository.GetPropertyByName(command.Name) is not null)
            {
                Error.Conflict("A Property with this name already exists.");
            }

            RegisterProperty property = _mapper.Map<RegisterProperty>(command);

            return _mapper.Map<PropertyResult>(await _propertyRepository.AddProperty(property));
        }
    }
}
