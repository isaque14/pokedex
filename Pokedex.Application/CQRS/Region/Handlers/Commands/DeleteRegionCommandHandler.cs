using FandomStarWars.Application.CQRS.BaseResponses;
using MediatR;
using Pokedex.Application.CQRS.Region.Requests.Commands;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Application.CQRS.Region.Handlers.Commands
{
    public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand, GenericResponse>
    {
        private readonly IRegionRepository _regionRepository;

        public DeleteRegionCommandHandler(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<GenericResponse> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var region = await _regionRepository.GetByIdAsync(request.Id);

                if (region is null)
                {
                    return new GenericResponse
                    {
                        IsSuccessful = false,
                        Message = "no region found for this id"
                    };
                }

                await _regionRepository.DeleteAsync(request.Id);

                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "successfully deleted region"
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
