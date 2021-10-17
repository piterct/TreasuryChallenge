using System.IO;
using System.Text;
using System.Threading.Tasks;
using TreasuryChallenge.Domain.Repositories;

namespace TreasuryChallenge.Infra.Repositories
{
    public class TextFileRepository : ITextFileRepository
    {
        public async Task WriteFile(string filename, string file)
        {
            string fileName = $@"{filename}.txt";

            int BufferSize = 65536;

            using (StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8, BufferSize))
            {
                await write.WriteAsync(file);
            };
        }
    }
}
