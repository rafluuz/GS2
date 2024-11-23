using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SustenAI.Models.Mappings
{
    public class DispositivoMapping : IEntityTypeConfiguration<Dispositivo>
    {
        public void Configure(EntityTypeBuilder<Dispositivo> builder)
        {
            builder.ToTable("TB_DISPOSITIVO");

            builder.HasKey(d => d.IdDispo);

            builder.Property(d => d.IdDispo)
                .HasColumnName("ID_DISPO")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.NomeDispo)
                .HasColumnName("NOME_DISPO")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.TipoDispo)
                .HasColumnName("TIPO_DISPO")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.DataInstalacao)
                .HasColumnName("DATA_INSTALACAO")
                .HasColumnType("DATE")
                .IsRequired();


        }
    }
}
