using FluentValidation.Results;

namespace Pokedex.Application.CQRS.Region.Requests.Commands.Base
{
    public class RegionCommand
    {
        public string ErrorMensage(List<ValidationFailure> errors)
        {
            var msg = "";
            foreach (var erro in errors)
            {
                msg = msg + $"{erro + System.Environment.NewLine} ";
            }
            return msg;
        }
    }
}
