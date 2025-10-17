using CrudToAlgo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudToAlgo.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<CasoTeste> CasosTeste { get; set; }
        public DbSet<Submissao> Submissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Desafio>().ToTable("desafios");
            modelBuilder.Entity<CasoTeste>().ToTable("casos_teste");
            modelBuilder.Entity<Submissao>().ToTable("submissoes");

            modelBuilder.Entity<CasoTeste>()
                .HasOne(c => c.Desafio)
                .WithMany(d => d.CasosTeste)
                .HasForeignKey(c => c.DesafioId);

            modelBuilder.Entity<Submissao>()
                .HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.UsuarioId);

            modelBuilder.Entity<Submissao>()
                .HasOne(s => s.Desafio)
                .WithMany()
                .HasForeignKey(s => s.DesafioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
