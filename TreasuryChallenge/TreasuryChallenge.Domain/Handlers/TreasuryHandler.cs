using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;
using TreasuryChallenge.Domain.Entity;

namespace TreasuryChallenge.Domain.Handlers
{
    public class TreasuryHandler : Notifiable
    {
        public async Task<GetLinesAmountToWriteCommandResult> Handle(GetLinesAmountToWriteCommandInput command)
        {
            var stopwatch = Stopwatch.StartNew();
            command.Validate();
            if (command.Invalid)
                return new GetLinesAmountToWriteCommandResult(false, "Incorrect  data!", stopwatch.ElapsedMilliseconds, StatusCodes.Status400BadRequest, command.Notifications);

            TextFile textFile = new TextFile("aleatory-file", 7);

            await textFile.WriteFile(command.LinesAmount);



            return new GetLinesAmountToWriteCommandResult(true, "Success!", stopwatch.ElapsedMilliseconds, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
