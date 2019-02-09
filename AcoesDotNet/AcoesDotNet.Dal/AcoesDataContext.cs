using AcoesDotNet.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AcoesDotNet.Dal
{
    public class AcoesDataContext : DbContext
    {
        private static string _connectionString;

        public AcoesDataContext()
        {
        }

        public AcoesDataContext(string connetionString)
        {
            _connectionString = connetionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
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
