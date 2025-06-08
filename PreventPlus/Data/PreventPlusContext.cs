using Microsoft.EntityFrameworkCore;
using PreventPlus.Models;

namespace PreventPlus.Data
{
    public class PreventPlusContext : DbContext
    {
        public PreventPlusContext(DbContextOptions<PreventPlusContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Regiao> Regioes { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Dica> Dicas { get; set; }
        public DbSet<HistoricoRisco> HistoricosRisco { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public DbSet<LocalSeguro> LocaisSeguros { get; set; }
        public DbSet<LocalFavorito> LocaisFavoritos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<TipoDesastre> TiposDesastre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checklist>().HasKey(c => c.IdChecklist);
            modelBuilder.Entity<Alerta>().HasKey(a => a.IdAlerta);
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");
            modelBuilder.Entity<Regiao>().ToTable("REGIAO");
            modelBuilder.Entity<Checklist>().ToTable("CHECKLIST");
            modelBuilder.Entity<Dica>().ToTable("DICA");
            modelBuilder.Entity<HistoricoRisco>().ToTable("HISTORICO_RISCO");
            modelBuilder.Entity<Kit>().ToTable("KIT");
            modelBuilder.Entity<LocalSeguro>().ToTable("LOCAL_SEGURO");
            modelBuilder.Entity<LocalFavorito>().ToTable("LOCAL_FAVORITO");
            modelBuilder.Entity<Notificacao>().ToTable("NOTIFICACAO");
            modelBuilder.Entity<Alerta>().ToTable("ALERTA");
            modelBuilder.Entity<TipoDesastre>().ToTable("TIPO_DESASTRE");
        }
    }
}