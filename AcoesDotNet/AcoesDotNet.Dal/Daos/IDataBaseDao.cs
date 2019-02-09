using System.Threading.Tasks;

namespace AcoesDotNet.Dal.Daos
{
    public interface IDataBaseDao
    {
        Task InicializaAsync(string connecionString);
    }
}