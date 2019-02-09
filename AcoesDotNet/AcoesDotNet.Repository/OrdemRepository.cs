using AcoesDotNet.Dal.Daos;
using AcoesDotNet.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcoesDotNet.Repository
{
    public class OrdemRepository : IOrdemRepository
    {
        private GenericDao<Ordem> _dao = new GenericDao<Ordem>();

        public Task<Ordem> Get(int id)
        {
            return _dao.GetById(id);
        }

        public Task<IEnumerable<Ordem>> GetAllAsync()
        {
            return _dao.GetAllAsyc();
        }

        public Task InsertAsync(Ordem ordem)
        {
            return _dao.InsertAsync(ordem);
        }
    }
}