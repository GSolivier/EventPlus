using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório que define os métodos implementados na Interface IComentarioRepository
    /// </summary>
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// 
        /// </summary>
        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> Listar(Guid idEvento)
        {
            throw new NotImplementedException();
        }

        public List<ComentarioEvento> ListarPorUsuario(Guid idUsuario)
        {
            throw new NotImplementedException();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }

}
