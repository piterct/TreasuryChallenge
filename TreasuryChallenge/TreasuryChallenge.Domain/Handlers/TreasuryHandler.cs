using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;
using TreasuryChallenge.Domain.Entities;
using TreasuryChallenge.Domain.Repositories;

namespace TreasuryChallenge.Domain.Handlers
{
    public class TreasuryHandler : Notifiable
    {
        private readonly ITextFileRepository _textFileRepository;
        public TreasuryHandler(ITextFileRepository textFileRepository)
        {
            _textFileRepository = textFileRepository;
        }
        public async Task<GetLinesAmountToWriteCommandResult> Handle(GetLinesAmountToWriteCommandInput command)
        {
            var stopwatch = Stopwatch.StartNew();
            command.Validate();
            if (command.Invalid)
                return new GetLinesAmountToWriteCommandResult(false, "Incorrect  data!", stopwatch.ElapsedMilliseconds, StatusCodes.Status400BadRequest, command.Notifications);

            TextFile textFile = new TextFile("aleatory-file", 7);

            StringBuilder file = await textFile.CreateFile(command.LinesAmount);
            await _textFileRepository.WriteFile(textFile.FileName, file.ToString());


            return new GetLinesAmountToWriteCommandResult(true, "Success!", stopwatch.ElapsedMilliseconds, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
