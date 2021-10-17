using System.IO;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Utils;

namespace TreasuryChallenge.Domain.Entity
{
    public class TextFile
    {
        public string FileName { get; set; }
        public int MaxLengthContent { get; set; }
        public TextFile(string fileName, int maxLengthContent)
        {
            this.FileName = fileName;
            this.MaxLengthContent = maxLengthContent;
        }

        public async Task<StringBuilder> WriteFile(int inputValue)
        {
            StringBuilder textFile = new StringBuilder();

            for (int i = 0; i < inputValue; i++)
            {
                textFile.Append(await GenerateContent()).AppendLine();
            };

            return textFile;
        }

        public async Task<string> GenerateContent(string updatedAlphabetLetters = "", string content = "")
        {
            string alphabetLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (content.Length > 0)
                alphabetLetters = updatedAlphabetLetters;

            if (content.Length == this.MaxLengthContent) return content;

            string charGenerated = TreasuryUtil.GetChar(alphabetLetters);

            if (content.Length != 0)
            {
                bool found = TreasuryUtil.FoundChar(content, charGenerated);
                while (found)
                {
                    alphabetLetters = alphabetLetters.Replace(charGenerated, "");
                    charGenerated = TreasuryUtil.GetChar(alphabetLetters);
                    found = TreasuryUtil.FoundChar(content, charGenerated);
                }
            }
            return await GenerateContent(alphabetLetters, content + charGenerated);
        }
    }
}
