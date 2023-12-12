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
        /// Construtor que instancia o objeto da context
        /// </summary>
        public ComentarioEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Método para cadastrar um novo comentário
        /// </summary>
        /// <param name="comentarioEvento">Objeto com os valores a serem cadastrados</param>
        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _eventContext.ComentarioEvento.Add(comentarioEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método para listar todos os comentários daquele evento
        /// </summary>
        /// <returns> Retorna a lista dos comentários</returns>
        public List<ComentarioEvento> Listar(Guid idEvento)
        {
            try
            {
               return _eventContext.ComentarioEvento.Where(ce => ce.IdEvento == idEvento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista todos os comentários de um determindado usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário que terá os seus comentários listados</param>
        /// <returns>Uma lista com os comentários do usuário</returns>
        public ComentarioEvento ListarPorUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return _eventContext.ComentarioEvento.Select(x => new ComentarioEvento
                {
                    IdComentarioEvento = x.IdComentarioEvento,
                    Descricao = x.Descricao,
                    Exibe = x.Exibe,
                    IdUsuario = x.IdUsuario,
                    IdEvento = x.IdEvento,

                    Usuario = new Usuario { 
                        IdUsuario = x.IdUsuario,
                        Nome = x.Usuario!.Nome
                    },
                    Evento = new Evento
                    {
                        IdEvento = x.IdEvento,
                        Nome = x.Evento!.Nome
                    }
                }
                ).FirstOrDefault(x => x.IdUsuario == idUsuario && x.IdEvento == idEvento)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar todos os comentários
        /// </summary>
        /// <returns>retorna uma lista com os objetos</returns>
        public List<ComentarioEvento> ListarTodos()
        {
            try
            {
               return _eventContext.ComentarioEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para buscar um comentário por ID
        /// </summary>
        /// <param name="id">ID do comentário que será buscado</param>
        /// <returns>Retorna o objeto com o comentário buscado</returns>
        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _eventContext.ComentarioEvento.FirstOrDefault(ce => ce.IdComentarioEvento == id)!;

                if (comentarioEventoBuscado == null)
                {
                    throw new Exception($"O comentário com o ID {id} não foi encontrado");
                }

                return comentarioEventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para deletar um comentário existente
        /// </summary>
        /// <param name="id"> ID do comentário que será deletado </param>
        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = BuscarPorId(id);

                _eventContext.ComentarioEvento.Remove(comentarioEventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> ListarSomenteExibe()
        {
            try
            {
                return _eventContext.ComentarioEvento.Select(x => new ComentarioEvento
                {
                    IdComentarioEvento = x.IdComentarioEvento,
                    Descricao = x.Descricao,
                    Exibe = x.Exibe,
                    IdUsuario = x.IdUsuario,
                    IdEvento = x.IdEvento,

                    Usuario = new Usuario
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Usuario!.Nome
                    },
                    Evento = new Evento
                    {
                        IdEvento = x.IdEvento,
                        Nome = x.Evento!.Nome
                    }
                }
                ).Where(c => c.Exibe == true).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
