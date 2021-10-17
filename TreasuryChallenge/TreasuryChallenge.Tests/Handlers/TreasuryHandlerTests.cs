using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasuryChallenge.Domain.Commands.Inputs;
using TreasuryChallenge.Domain.Commands.Result;
using TreasuryChallenge.Domain.Handlers;
using TreasuryChallenge.Domain.Repositories;
using TreasuryChallenge.Tests.Fakes;

namespace TreasuryChallenge.Tests.Handlers
{
    [TestClass]
    public class TreasuryHandlerTests
    {
        private readonly FakeTextFileRepository _fakeTextFileRepository;
        private readonly TreasuryHandler _treasuryHandler;
        private readonly GetLinesAmountToWriteCommandInput _getLinesAmountToWriteCommandInput;
        private readonly GetLinesAmountToWriteCommandInput _getLinesAmountToWriteCommandInputZeroLine;

        public TreasuryHandlerTests()
        {
            _fakeTextFileRepository = new FakeTextFileRepository();
            _treasuryHandler = new TreasuryHandler(_fakeTextFileRepository);
            _getLinesAmountToWriteCommandInput = new GetLinesAmountToWriteCommandInput(10);
            _getLinesAmountToWriteCommandInputZeroLine = new GetLinesAmountToWriteCommandInput(0);
        }

        [TestMethod]
        public void Call_WriteCodeInFile_MustExecuteSuccessfully()
        {
            GetLinesAmountToWriteCommandResult handler = _treasuryHandler.Handle(_getLinesAmountToWriteCommandInput).Result;

            Assert.IsTrue(handler.Success);
        }

        [TestMethod]
        public void Call_WriteCodeInFile_MustExecuteFail()
        {
            GetLinesAmountToWriteCommandResult handler = _treasuryHandler.Handle(_getLinesAmountToWriteCommandInputZeroLine).Result;

            Assert.IsFalse(handler.Success);
        }
    }
}
