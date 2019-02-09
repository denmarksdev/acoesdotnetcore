using AcoesDotNet.Dal.Daos;
using System.Threading.Tasks;

namespace AcoesDotNet.Repository
{
    public class DataBaseRepository : IDatabaseRepository
    {
        private IDataBaseDao _dataBaseDao = new DataBaseDao();

        public Task InicializaAsync(string connecionString)
        {
            return _dataBaseDao.InicializaAsync(connecionString);
        }
    }
}
