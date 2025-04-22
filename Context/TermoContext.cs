using entity.Model;
using Microsoft.EntityFrameworkCore;

namespace entity.Context
{
    public class TermoContext : DbContext
    {
        public TermoContext(DbContextOptions<TermoContext> options) : base(options) { }

        public DbSet<Termo> termo { get; set; }

        public DbSet<CadTermoItemAceiteUsuarioHistorico> cadTermoItems { get; set; }

        public DbSet<CadTermoItem> termoItems { get; set; }

        public DbSet<CadTermoItemAceite> itemAceites { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definindo chave composta

            modelBuilder.Entity<Termo>()
                .HasOne(t => t.usuario)
                .WithMany() 
                .HasForeignKey(t => t.usuario_codigo);


            modelBuilder.Entity<CadTermoItemAceiteUsuarioHistorico>()
                .HasKey(c => new { c.usuario_codigo });

            modelBuilder.Entity<CadTermoItem>()
                .HasOne(i => i.Termo)
                .WithMany()
                .HasForeignKey(i => i.termo_codigo);





            modelBuilder.Entity<CadTermoItemAceiteUsuarioHistorico>()
                .HasOne(c => c.Termo)
                .WithMany(t => t.Historicos)
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}
