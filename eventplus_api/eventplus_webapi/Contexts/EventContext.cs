using eventplus_webapi.Domains;
using Microsoft.EntityFrameworkCore;

namespace eventplus_webapi.Contexts
{
    public class EventContext : DbContext
    {
        /// <summary>
        /// Referencia a tabela TiposUsuario no banco de dados
        /// </summary>
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        /// <summary>
        /// Referencia a tabela Usuario no banco de dados
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Referencia a tabela TiposEvento no banco de dados
        /// </summary>
        public DbSet<TiposEvento> TiposEvento { get; set; }

        /// <summary>
        /// Referencia a tabela Evento no banco de dados
        /// </summary>
        public DbSet<Evento> Evento { get; set; }

        /// <summary>
        /// Referencia a tabela ComentarioEvento no banco de dados
        /// </summary>
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }

        /// <summary>
        /// Referencia a tabela Instituicao no banco de dados
        /// </summary>
        public DbSet<Instituicao> Instituicao { get; set; }

        /// <summary>
        /// Referencia a tabela PresencaEvento no banco de dados
        /// </summary>
        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        /// <summary>
        /// Configuração da conexão com o banco de dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto para acessar a string de conexão</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE18-S14; Database=Event+_Manha; User id=sa; pwd=Senai@134; TrustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Server=GUILHERME\\SQLEXPRESS; Database=Event+_Manha; User id=sa; pwd=Senai@134; TrustServerCertificate=true");
            //base.OnConfiguring(optionsBuilder);
        }


    }
}
