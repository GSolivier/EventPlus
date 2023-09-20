using eventplus_webapi.Domains;
using Microsoft.EntityFrameworkCore;

namespace eventplus_webapi.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=NOTE18-S14; Database=Event+_Manha; User id=sa; pwd=Senai@134; TrustServerCertificate=true");
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=GUILHERME\\SQLEXPRESS; Database=Event+_Manha; User id=sa; pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
