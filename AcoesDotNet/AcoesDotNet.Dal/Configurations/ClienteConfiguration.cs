using AcoesDotNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoesDotNet.Dal.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entidade)
        {
            entidade.ToTable("Clientes");

            entidade.Property(c => c.Nome)
                .IsRequired();
            entidade.HasIndex(c => c.Nome)
                .IsUnique();

            entidade.Property(c => c.DataNascimento)
                .IsRequired();

            entidade.Property(c => c.TipoPessoa)
                .IsRequired();

            entidade.Property(c => c.CnpjCpf)
                .HasMaxLength(20);
        }
    }
}
