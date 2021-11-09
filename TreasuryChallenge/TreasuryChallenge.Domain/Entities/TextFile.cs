using System.IO;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Utils;

namespace TreasuryChallenge.Domain.Entities
{
    public class TextFile
    {
        public string FileName { get; private set; }
        public int MaxLengthContent { get; private set; }
        public string Characters { get; private set; }
        public TextFile(string fileName, int maxLengthContent, string characters)
        {
            this.FileName = fileName;
            this.MaxLengthContent = maxLengthContent;
            this.Characters = characters;
        }

        public async Task<StringBuilder> CreateFile(int lines)
        {
            StringBuilder textFile = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                string text = TreasuryUtil.RandomWord(this.MaxLengthContent, this.Characters);
                textFile.Append(text).AppendLine();
            };

            return await Task.FromResult(textFile);
        }

        public async Task<StringBuilder> CreateFileOld(int inputValue)
        {
            StringBuilder textFile = new StringBuilder();

            for (int i = 0; i < inputValue; i++)
            {
                textFile.Append(await GenerateContentOld()).AppendLine();
            };

            return textFile;
        }


        public async Task<string> GenerateContentOld(string updatedAlphabetLetters = "", string content = "")
        {
            string alphabetLetters = this.Characters;
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
            return await GenerateContentOld(alphabetLetters, content + charGenerated);
        }
    }
}
