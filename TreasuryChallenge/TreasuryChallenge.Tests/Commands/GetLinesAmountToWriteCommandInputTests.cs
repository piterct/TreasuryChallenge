using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasuryChallenge.Domain.Commands.Inputs;

namespace TreasuryChallenge.Tests.Commands
{
    [TestClass]
    public class GetLinesAmountToWriteCommandInputTests
    {
        [TestMethod]
        [TestCategory("Commands")]

        public void Valid_CommandAmountToWriteLines_ReturnTrue()
        {
            GetLinesAmountToWriteCommandInput command = new GetLinesAmountToWriteCommandInput(5);
            command.Validate();

            Assert.IsTrue(command.Valid);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Valid_CommandAmountToWriteLines_Returnfalse_Value_Zero()
        {
            GetLinesAmountToWriteCommandInput command = new GetLinesAmountToWriteCommandInput(0);
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Valid_CommandAmountToWriteLines_Returnfalse_Value_Empty()
        {
            GetLinesAmountToWriteCommandInput command = new GetLinesAmountToWriteCommandInput();
            command.Validate();

            Assert.IsTrue(command.Invalid);
        }
    }
}
