using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasuryChallenge.Domain.Entities;

namespace TreasuryChallenge.Tests.Entities
{
    [TestClass]
    public class TextFileTests
    {
        [TestMethod]
        public void Generete_Char_ReturnTotalCharEqualThePastValue()
        {
            TextFile txtFile = new TextFile("file-teste", 8);
            string content = txtFile.GenerateContent().Result;

            Assert.AreEqual(8, content.Length);
        }
    }
}
