using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;
using TreasuryChallenge.Domain.Entities;
using TreasuryChallenge.Domain.Repositories;
using TreasuryChallenge.Shared.Settings;

namespace TreasuryChallenge.Domain.Handlers
{
    public class TreasuryHandler : Notifiable
    {
        private readonly ITextFileRepository _textFileRepository;
        private readonly TreasurySettings _treasurySettings;
        public TreasuryHandler(IOptions<TreasurySettings> treasurySettings, ITextFileRepository textFileRepository)
        {
            _treasurySettings = treasurySettings.Value;
            _textFileRepository = textFileRepository;

        }
        public async Task<GetLinesAmountToWriteCommandResult> Handle(GetLinesAmountToWriteCommandInput command)
        {
            var stopwatch = Stopwatch.StartNew();
            command.Validate();
            if (command.Invalid)
                return new GetLinesAmountToWriteCommandResult(false, "Incorrect  data!", stopwatch.ElapsedMilliseconds, StatusCodes.Status400BadRequest, command.Notifications);

            TextFile textFile = new TextFile(_treasurySettings.NameFile, _treasurySettings.MaxLengthCode, _treasurySettings.Characters);

            StringBuilder file = await textFile.CreateFile(command.LinesAmount);
            await _textFileRepository.WriteFile(textFile.FileName, file.ToString());

            return new GetLinesAmountToWriteCommandResult(true, $"A file with { command.LinesAmount } lines was generated.", stopwatch.ElapsedMilliseconds, StatusCodes.Status200OK, command.Notifications);
        }
    }
}
