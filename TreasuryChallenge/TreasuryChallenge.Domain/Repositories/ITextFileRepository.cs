using System.Threading.Tasks;

namespace TreasuryChallenge.Domain.Repositories
{
    public interface ITextFileRepository
    {
        Task WriteFile(string filename, string file);
    }
}
