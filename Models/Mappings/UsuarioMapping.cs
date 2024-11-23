using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SustenAI.Models.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_USUARIO");

            builder.HasKey(u => u.IdUser);

            builder.Property(u => u.IdUser)
                .HasColumnName("ID_USER")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(15);

            builder.Property(u => u.DataCriacao)
                .HasColumnName("DATA_CRIACAO")
                .HasColumnType("DATE")
                .IsRequired();
        }
    }
}