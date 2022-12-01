using Microsoft.EntityFrameworkCore;
using WebApiRifa.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApiRifa
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RifaParticipante>()
                .HasKey(pl => new { pl.RifaId, pl.ParticipanteId, pl.CartaId });
        }

        public DbSet<Rifa> Rifas { get; set; }

        public DbSet<Participante> Participantes { get; set; }

        public DbSet<RifaParticipante> RifaParticipantes { get; set; }

        public DbSet<Premios> Premios { get; set; }

        public DbSet<Cartas> Cartas { get; set; }
    }
}
