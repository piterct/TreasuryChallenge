using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<List<string>> CreateWords(int lines)
        {
            List<string> listWords = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string text = TreasuryUtil.RandomWord(this.MaxLengthContent, this.Characters);
                listWords.Add(text);
            };

            return await Task.FromResult(listWords);
        }

        public async Task<List<string>> GetDuplicateWords(List<string> words)
        {
            List<string> duplicates = words.GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(x => x.Key).ToList();

            return await Task.FromResult(duplicates);
        }

        [Obsolete]
        public async Task<StringBuilder> CreateFileOld(int inputValue)
        {
            StringBuilder textFile = new StringBuilder();

            for (int i = 0; i < inputValue; i++)
            {
                textFile.Append(await GenerateContentOld()).AppendLine();
            };

            return textFile;
        }

        [Obsolete]
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
