using System.Threading.Tasks;
using TreasuryChallenge.Domain.Repositories;

namespace TreasuryChallenge.Tests.Fakes
{
    public class FakeTextFileRepository : ITextFileRepository
    {
        public Task WriteFile(string filename, string file)
        {
            return Task.FromResult(true);
        }
    }
}
