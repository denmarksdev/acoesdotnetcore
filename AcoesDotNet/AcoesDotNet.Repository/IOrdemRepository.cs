using System.Collections.Generic;
using System.Threading.Tasks;
using AcoesDotNet.Model;

namespace AcoesDotNet.Repository
{
    public interface IOrdemRepository
    {
        Task<IEnumerable<Ordem>> GetAllAsync();
        Task<Ordem> GetByIdAsync(int id);
        Task InsertAsync(Ordem ordem);
    }
}