using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Requests.Commands.Base;
using Pokedex.Application.CQRS.Region.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Region.Handlers.Commands
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, GenericResponse>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ValidateCreateRegion _validator;

        public CreateRegionCommandHandler(IRegionRepository regionRepository, IMapper mapper, ValidateCreateRegion validator)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Oops! Review the data you provided",
                    Object = request.ErrorMensage(results.Errors)
                };
            }

            var region = new Domain.Entities.Region(request.Name);

            try
            {
                await _regionRepository.CreateAsync(region);
                var regionDTO = _mapper.Map<RegionDTO>(region);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully created region",
                    Object = regionDTO
                };
            }
            catch (Exception e)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = e.Message
                };
            }
        }
    }
}
