using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AcoesDotNet.Dal.Daos
{
    public class DataBaseDao : IDataBaseDao
    {
        public async Task InicializaAsync(string connecionString)
        {
           using (var db = new AcoesDataContext(connecionString))
           {
               await db.Database.MigrateAsync();
           }
        }
    }
}
