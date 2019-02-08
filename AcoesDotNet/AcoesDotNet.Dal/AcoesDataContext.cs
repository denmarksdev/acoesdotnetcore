using AcoesDotNet.Dal.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AcoesDotNet.Dal
{
    public class AcoesDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: Mover para arquivo de configuração
            optionsBuilder.UseSqlite("Data Source=acaodb.db");
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
