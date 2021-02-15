using System.Data.Entity.ModelConfiguration;
using WiproPriceSystem.Domain.Entities;

namespace WiproPriceSystem.Infra.EF.Mapping
{
    public class FilaMapping : EntityTypeConfiguration<Fila>
    {
        public FilaMapping()
        {
            this.HasKey(t => t.FilaId);

            this.Property(t => t.Moeda).IsRequired().HasMaxLength(3);
            this.Property(t => t.DataInicio).IsRequired();
            this.Property(t => t.DataFim).IsRequired();

            this.ToTable("Fila", "dbo");
            this.Property(t => t.FilaId).HasColumnName("FilaId");
            this.Property(t => t.Moeda).HasColumnName("Moeda");
            this.Property(t => t.DataInicio).HasColumnName("DataInicio");
            this.Property(t => t.DataFim).HasColumnName("DataFim");
        }
    }
}