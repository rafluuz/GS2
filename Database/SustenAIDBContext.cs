using Microsoft.EntityFrameworkCore;
using SustenAI.Models;
using SustenAI.Models.Mappings;

namespace SustenAI.DataBase
{
    public class SustenAIDBContext : DbContext
    {

        public SustenAIDBContext(DbContextOptions<SustenAIDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new AlertaMapping());
            modelBuilder.ApplyConfiguration(new DispositivoMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}

