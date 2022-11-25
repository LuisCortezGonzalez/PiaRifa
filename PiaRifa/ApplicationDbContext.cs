using Microsoft.EntityFrameworkCore;
using WebApiRifa.Entidades;

namespace WebApiRifa
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RifaParticipante>()
                .HasKey(pl => new { pl.RifaId, pl.ParticipanteId });
        }

        public DbSet<Rifa> Rifas { get; set; }

        public DbSet<Participante> Participantes { get; set; }

        public DbSet<RifaParticipante> RifaParticipantes { get; set; }
    }
}
