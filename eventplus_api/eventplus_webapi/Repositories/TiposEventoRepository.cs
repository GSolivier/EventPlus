using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório para armazenar os métodos implementados pela interface
    /// </summary>
    public class TiposEventoRepository : ITiposEventoRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor para instanciar um novo objeto do contexto
        /// </summary>
        public TiposEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Método responsável por cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto com os atributos que serão cadastrados</param>
        public void Cadastrar(TiposEvento tipoEvento)
        {
            try
            {
                _eventContext.Add(tipoEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Método responsável por listar todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna a lista com todos os tipos de eventos</returns>
        public List<TiposEvento> Listar()
        {
            try
            {
                return _eventContext.TiposEvento.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por atualizar um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEvento">objeto com os novos dados para atualizar</param>
        public void Atualizar(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                TiposEvento tipoEventoBuscado = BuscarPorId(id);

                tipoEventoBuscado.Titulo = tipoEvento.Titulo;

                _eventContext.TiposEvento.Update(tipoEventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por deletar um tipo de evento
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        public void Deletar(Guid id)
        {
            try
            {
                TiposEvento tipoEventoBuscado = BuscarPorId(id);

                _eventContext.TiposEvento.Remove(tipoEventoBuscado);

                _eventContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por buscar um tipo de evento por seu ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        public TiposEvento BuscarPorId(Guid id)
        {
            try
            {
                TiposEvento tipoEventoBuscado = _eventContext.TiposEvento.FirstOrDefault(tp => tp.IdTipoEvento == id)!;

                if (tipoEventoBuscado == null)
                {
                    throw new Exception($"Tipo de evento com o ID {id} não encontrado");
                }

                return tipoEventoBuscado;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
