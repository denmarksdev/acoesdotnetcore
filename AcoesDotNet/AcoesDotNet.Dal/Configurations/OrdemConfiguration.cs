using AcoesDotNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoesDotNet.Dal.Configurations
{
    class OrdemConfiguration : IEntityTypeConfiguration<Ordem>
    {
        public void Configure(EntityTypeBuilder<Ordem> entidade)
        {
            entidade.ToTable("Ordens");

            entidade.Property(o => o.TipoOrdem)
                .IsRequired();

            entidade.Property(o => o.DataOrdem)
                .IsRequired();

            entidade.Property(o => o.IdCliente)
                .IsRequired();

            entidade.Property(o => o.CodigoAcao)
                .IsRequired();

            entidade.Property(o => o.QuantidadeAcoes)
                .IsRequired();
        }
    }
}
