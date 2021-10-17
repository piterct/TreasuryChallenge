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

        [TestMethod]
        public void Valid_OneCharInsideOfString_ReturnFalse()
        {
            string content = "UJHSNKL";
            bool result = TreasuryUtil.FoundChar(content, "Y");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Generete_Char_ReturnStringLengthEqualOne()
        {
            string alphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string resultChar = TreasuryUtil.GetChar(alphabetLetters);

            Assert.AreEqual(1, resultChar.Length);
        }
    }
}
