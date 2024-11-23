using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SustenAI.Models.Mappings
{
    public class AlertaMapping : IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.ToTable("TB_ALERTA");

            builder.HasKey(a => a.IdAlerta);

            builder.Property(a => a.IdAlerta)
                .HasColumnName("ID_ALERTA")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.TipoAlerta)
                .HasColumnName("TIPO_ALERTA")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.Mensagem)
                .HasColumnName("MENSAGEM")
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(a => a.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .HasColumnType("DATE")
                .IsRequired();

            builder.Property(a => a.StatusAlerta)
                .HasColumnName("STATUS_ALERTA")
                .HasMaxLength(20);

        }
    }
}
