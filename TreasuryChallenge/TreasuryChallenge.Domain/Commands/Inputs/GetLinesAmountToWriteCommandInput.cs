using Flunt.Notifications;
using Flunt.Validations;
using TreasuryChallenge.Shared.Commands.Contracts;

namespace TreasuryChallenge.Domain.Commands.Inputs
{
    public class GetLinesAmountToWriteCommandInput : Notifiable, ICommand
    {
        public int LinesAmount { get; set; }

        public void Validate()
        {
            AddNotifications(
           new Contract()
               .Requires()
               .IsNotNull(LinesAmount, "LinesAmount", "This value is not valid!")
                );
        }
    }
}
