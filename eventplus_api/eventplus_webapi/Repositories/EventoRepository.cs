using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório que define a lógica dos métodos implementados pela interface IEventoRepository
    /// </summary>
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor responsável por instaciar o objeto _eventContext
        /// </summary>
        public EventoRepository()
        {
              _eventContext = new EventContext();
        }

        /// <summary>
        /// Método de cadastro de um novo evento
        /// </summary>
        /// <param name="evento">Objeto que terá os dados a serem adicionados</param>
        public void Cadastrar(Evento evento)
        {
            try
            {
                _eventContext.Evento.Add(evento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para listar todos os eventos
        /// </summary>
        /// <returns>Retorna a lista de todos os eventos</returns>
        public List<Evento> Listar()
        {
            try
            {
                return _eventContext.Evento.Select(e => new Evento
                {
                    IdEvento = e.IdEvento,
                    DataEvento = e.DataEvento,
                    Nome = e.Nome,
                    Descricao = e.Descricao,
                    TiposEvento = new TiposEvento
                    {
                        IdTipoEvento = e.IdTipoEvento,
                        Titulo = e.TiposEvento!.Titulo
                    },
                    IdInstituicao = e.IdInstituicao,
                    Instituicao = new Instituicao
                    {   
                        IdInstituicao = e.IdInstituicao,
                        NomeFantasia = e.Instituicao!.NomeFantasia
                    }
                }).ToList(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que lista todos os eventos a partir da data atual
        /// </summary>
        /// <returns>Retorna a lista dos próximos eventos</returns>
        public List<Evento> ListarProximos()
        {
            try
            {
                return _eventContext.Evento.Where(e => e.DataEvento >= DateTime.Now).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para atualizar um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="evento">Objeto com as novas informações a serem inseridas</param>
        public void Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = BuscarPorId(id);

                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Nome = evento.Nome;
                eventoBuscado.Descricao = evento.Descricao;

                if(evento.IdTipoEvento != Guid.Empty)
                {
                   eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                }

                if (evento.IdInstituicao != Guid.Empty)
                {
                   eventoBuscado.IdInstituicao = evento.IdInstituicao;
                }
                
                _eventContext.Evento.Update(eventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método que exclui um Evento Existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        public void Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = BuscarPorId(id);

                _eventContext.Remove(eventoBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Método para buscar um evento pelo seu ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>retorna o evento buscado</returns>
        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventContext.Evento.Select(e => new Evento
                    {
                        IdEvento = e.IdEvento,
                        DataEvento = e.DataEvento,
                        Nome = e.Nome,
                        Descricao = e.Descricao,
                        TiposEvento = new TiposEvento
                        {
                            IdTipoEvento = e.IdTipoEvento,
                            Titulo = e.TiposEvento!.Titulo
                        },
                        IdInstituicao = e.IdInstituicao,
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = e.IdInstituicao,
                            NomeFantasia = e.Instituicao!.NomeFantasia
                        }
                    }).FirstOrDefault(e => e.IdEvento == id)!;

                if (eventoBuscado == null)
                {
                    throw new Exception($"O evento com o ID {id} não foi encontrado");
                }

                return eventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
