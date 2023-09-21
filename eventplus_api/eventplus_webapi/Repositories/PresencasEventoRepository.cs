using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório responsável por definir as lógicas dos métodos implementados pela Interface IPresencasEventoRepository
    /// </summary>
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor responsável pela implementação do objeto da context
        /// </summary>
        public PresencasEventoRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Método responsável por cadastrar uma nova Presença
        /// </summary>
        /// <param name="presencasEvento">Objeto com os atributos a serem cadastrados</param>
        public void Cadastrar(PresencasEvento presencasEvento)
        {
            try
            {
                _eventContext.PresencasEvento.Add(presencasEvento);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar todas as presenças
        /// </summary>
        /// <returns>Retorna uma lista com todas as presenças</returns>
        public List<PresencasEvento> Listar()
        {
            try
            {
                return _eventContext.PresencasEvento.Include(pe => pe.Usuario).Include(pe => pe.Evento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar as presenças de um determinado usuário
        /// </summary>
        /// <param name="idUsuario">As presenças serão buscadas a partir do ID do usuário</param>
        /// <returns>Retorna a lista filtrada</returns>
        public List<PresencasEvento> ListarPresencasUser(Guid idUsuario)
        {
            try
            {
                return _eventContext.PresencasEvento.Where(pe => pe.IdUsuario == idUsuario).Include(pe => pe.Usuario).Include(pe => pe.Evento).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por atualizar uma presença
        /// </summary>
        /// <param name="id">ID da presença que será atualizada</param>
        /// <param name="presencasEvento">objeto com os novos valores a serem adicionados</param>
        public void Atualizar(Guid id, PresencasEvento presencasEvento)
        {
            try
            {
                PresencasEvento presencaEventoEncontrado = _eventContext.PresencasEvento.FirstOrDefault(pe => pe.IdPresencaEvento == id)!;

                if (presencaEventoEncontrado == null)
                {
                    throw new Exception($"A presença de evento com o ID {id} não foi encontrada");
                }

                presencaEventoEncontrado.Situacao = presencasEvento.Situacao;

                _eventContext.PresencasEvento.Update(presencaEventoEncontrado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método que é responsável por deletar uma presença
        /// </summary>
        /// <param name="id">ID da presença que será deletada</param>
        public void Deletar(Guid id)
        {
            try
            {
                PresencasEvento presencaEventoEncontrado = _eventContext.PresencasEvento.FirstOrDefault(pe => pe.IdPresencaEvento == id)!;

                if (presencaEventoEncontrado == null)
                {
                    throw new Exception($"A presença de evento com o ID {id} não foi encontrada");
                }
                
                _eventContext.PresencasEvento.Remove(presencaEventoEncontrado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
