using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface que é responsável por definir os métodos da entidade Evento
    /// </summary>
    public interface IEventoRepository
    {
        /// <summary>
        /// Método de cadastro de um novo evento
        /// </summary>
        /// <param name="evento">Objeto que terá os dados a serem adicionados</param>
        void Cadastrar(Evento evento);

        /// <summary>
        /// Método que exclui um Evento Existente
        /// </summary>
        /// <param name="id">ID do evento que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para listar todos os eventos
        /// </summary>
        /// <returns>Retorna a lista de todos os eventos</returns>
        List<Evento> Listar();

        /// <summary>
        /// Método que lista todos os eventos a partir da data atual
        /// </summary>
        /// <returns>Retorna a lista dos próximos eventos</returns>
        List<Evento> ListarProximos();

        /// <summary>
        /// Método para buscar um evento pelo seu ID
        /// </summary>
        /// <param name="id">ID do evento que será buscado</param>
        /// <returns>retorna o evento buscado</returns>
        Evento BuscarPorId(Guid id);

        /// <summary>
        /// Método para atualizar um evento existente
        /// </summary>
        /// <param name="id">ID do evento que será atualizado</param>
        /// <param name="evento">Objeto com as novas informações a serem inseridas</param>
        void Atualizar(Guid id, Evento evento);
    }
}
