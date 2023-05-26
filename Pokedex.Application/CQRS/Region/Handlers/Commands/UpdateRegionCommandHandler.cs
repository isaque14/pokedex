using AutoMapper;
using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Application.CQRS.Region.Validations;
using Pokedex.Application.DTOs;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Region.Handlers.Commands
{
    public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, GenericResponse>
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ValidateUpdateRegion _validator;

        public UpdateRegionCommandHandler(IRegionRepository regionRepository, IMapper mapper, ValidateUpdateRegion validator)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<GenericResponse> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {
            var results = _validator.Validate(request);

            if (!results.IsValid)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Oops! Review the data you provided",
                    Object = request.ErrorMensage(results.Errors)
                };
            }

            try
            {
                var region = await _regionRepository.GetByIdAsync(request.Id);

                if (region is null) 
                {
                    return new GenericResponse
                    {
                        IsSuccessful = false,
                        Message = "no region found for this id",
                        Object = request.ErrorMensage(results.Errors)
                    };
                }

                region.Update(request.Name);
                await _regionRepository.UpdateAsync(region);
                var regionDTO = _mapper.Map<RegionDTO>(region);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully Updated region",
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
