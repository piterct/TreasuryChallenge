using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TreasuryChallenge.Infra.Repositories
{
    public class TextFileRepository
    {
        public async Task WriteFile(string filename, string file)
        {
            string fileName = $@"{filename}.txt";

            int BufferSize = 65536;

            using (StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8, BufferSize))
            {

                await write.WriteLineAsync(file);

            };
        }
    }
}
