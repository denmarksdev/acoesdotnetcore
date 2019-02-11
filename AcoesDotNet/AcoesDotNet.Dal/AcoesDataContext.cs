using AcoesDotNet.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AcoesDotNet.Dal
{
    public class AcoesDataContext : DbContext
    {
        // TODO: Carregar arquivo de configuracao
        private static string _connectionString = "localhost\\SQLEXPRESS;Database=acoes_migration;Trusted_Connection=True;";

        public AcoesDataContext()
        {
        }

        public AcoesDataContext(string connetionString)
        {
            _connectionString = connetionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO:Refatorar 
            if (_connectionString.Contains("Data Source"))
            {
                optionsBuilder.UseSqlite(_connectionString);
            }
            else
            {
                 optionsBuilder.UseSqlServer(_connectionString);

            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new AcaoConfiguration());
            modelBuilder.ApplyConfiguration(new OrdemConfiguration());
        }
    }
}
