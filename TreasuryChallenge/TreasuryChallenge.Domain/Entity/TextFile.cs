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

        public async Task WriteFile(int inputValue)
        {
            string fileName = $@"{this.FileName}.txt";
            int BufferSize = 65536;

            using (StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8, BufferSize))
            {
                for (int i = 0; i < inputValue; i++)
                {
                    await write.WriteLineAsync(await GenerateContent());
                };
            };
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
