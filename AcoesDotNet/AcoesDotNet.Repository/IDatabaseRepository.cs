using System.Threading.Tasks;

namespace AcoesDotNet.Repository
{
    public interface IDatabaseRepository
    {
        Task InicializaAsync(string connecionString);
    }
}
