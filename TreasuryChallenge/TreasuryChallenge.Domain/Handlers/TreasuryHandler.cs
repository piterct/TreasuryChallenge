using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;

namespace TreasuryChallenge.Domain.Handlers
{
    public class TreasuryHandler : Notifiable
    {
        public async Task<GetLinesAmountToWriteCommandResult> Handle(GetLinesAmountToWriteCommandInput command)
        {
            command.Validate();
            if (command.Invalid)
                return new GetLinesAmountToWriteCommandResult(false, "Incorrect  data!", StatusCodes.Status400BadRequest, command.Notifications);

            return new GetLinesAmountToWriteCommandResult(true, "Success!", StatusCodes.Status200OK, command.Notifications);
        }
    }
}
