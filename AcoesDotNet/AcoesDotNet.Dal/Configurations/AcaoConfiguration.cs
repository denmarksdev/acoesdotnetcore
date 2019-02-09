using AcoesDotNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcoesDotNet.Dal.Configurations
{
    public class AcaoConfiguration : IEntityTypeConfiguration<Acao>
    {
        public void Configure(EntityTypeBuilder<Acao> entidade)
        {
            entidade.ToTable("Acoes");

            entidade.Property(c => c.CodigoDaAcao)
                .IsRequired()
                .HasMaxLength(10);

            entidade.Property(c => c.DataCotacao)
                .IsRequired();

            entidade.Property(c => c.Valor)
                .IsRequired();
        }
    }
}
