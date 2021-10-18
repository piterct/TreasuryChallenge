using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasuryChallenge.Domain.Entities;

namespace TreasuryChallenge.Tests.Entities
{
    [TestClass]
    public class TextFileTests
    {
        private readonly TextFile _textFile;

        public TextFileTests()
        {
            _textFile = new TextFile("file-teste", 8, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Generete_Char_ReturnTotalCharEqualThePastValue()
        {
            string content = _textFile.GenerateContent().Result;

            Assert.AreEqual(8, content.Length);
        }

        [TestMethod]
        [TestCategory("Entities")]
        public void Generete_Char_ReturnTotalCharDifferentThePastValue()
        {
            string content = _textFile.GenerateContent().Result;

            Assert.AreNotEqual(2, content.Length);
        }
    }
}
