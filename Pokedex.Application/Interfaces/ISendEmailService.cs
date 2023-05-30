using FandomStarWars.Application.CQRS.BaseResponses;

namespace Pokedex.Application.Interfaces
{
    public interface ISendEmailService
    {
        Task<GenericResponse> SendEmail(string email, string subject, string content);
    }
}
