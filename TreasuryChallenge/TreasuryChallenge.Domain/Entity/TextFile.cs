using System.IO;
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

        public void WriteFile(int inputValue)
        {
            string fileName = $@"{this.FileName}.txt";

            using (StreamWriter write = new StreamWriter(fileName))
            {
                for (int i = 0; i < inputValue; i++)
                {
                    write.WriteLine(GenerateContent(string.Empty));
                };
            };
        }

        public string GenerateContent(string updatedAlphabetLetters = "", string content = "")
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
            return GenerateContent(alphabetLetters, content + charGenerated);
        }
    }
}
