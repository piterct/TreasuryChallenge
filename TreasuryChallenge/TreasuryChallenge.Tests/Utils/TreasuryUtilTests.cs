using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasuryChallenge.Domain.Utils;

namespace TreasuryChallenge.Tests.Utils
{
    [TestClass]
    public class TreasuryUtilTests
    {
        [TestMethod]
        public void Valid_OneCharInsideOfString_ReturnTrue()
        {
            string content = "UJHSNKL";
            bool result = TreasuryUtil.FoundChar(content, "U");

            Assert.IsTrue(result);
        }
    }
}
