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

                if (!System.IO.File.Exists("acao_dotnet.db")) {
                    System.IO.File.Create("acao_dotnet.db");
                }

               await db.Database.MigrateAsync();
           }
        }
    }
}
