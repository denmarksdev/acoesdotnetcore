using System.Collections.Generic;
using System.Threading.Tasks;
using AcoesDotNet.Model;

namespace AcoesDotNet.Repository
{
    public interface IOrdemRepository
    {
        Task<IEnumerable<Ordem>> GetAllAsync();
        Task InsertAsync(Ordem ordem);
    }
}