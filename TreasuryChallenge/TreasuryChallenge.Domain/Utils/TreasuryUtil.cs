using System;

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
    }
}
