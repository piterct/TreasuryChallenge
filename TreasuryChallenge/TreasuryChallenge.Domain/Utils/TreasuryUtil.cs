using System;
using System.Linq;
using System.Text;

namespace TreasuryChallenge.Domain.Utils
{
    public static class TreasuryUtil
    {
        public static string GetChar(string alhabehticLetters)
        {
            Random random = new Random();
            char[] chars = alhabehticLetters.ToCharArray(0, alhabehticLetters.Length);

            return chars[random.Next(alhabehticLetters.Length - 1)].ToString();
        }
        public static bool FoundChar(string content, string charGenerated)
        {
            return (content.ToUpper().Contains(charGenerated.ToUpper()));
        }

        public static string RandomWord(int length, string alhabehticLetters)
        {
            var chars = alhabehticLetters; 
            var random = new Random();

            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = chars[random.Next(0, chars.Length)];
                chars = chars.Replace(c.ToString(), "");
                builder.Append(c);
            }

            return builder.ToString().Trim();
        }
    }
}
