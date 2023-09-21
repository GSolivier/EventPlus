using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        public ComentarioEvento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
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
    }
}
