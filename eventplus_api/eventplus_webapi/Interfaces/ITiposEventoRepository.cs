using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável por definir os métodos da entidade TiposEvento
    /// </summary>
    public interface ITiposEventoRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto com os atributos que serão cadastrados</param>
        void Cadastrar(TiposEvento tipoEvento);

        /// <summary>
        /// Método responsável por deletar um tipo de evento
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método responsável por listar todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna a lista com todos os tipos de eventos</returns>
        List<TiposEvento> Listar();

        /// <summary>
        /// Método responsável por buscar um tipo de evento por seu ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        TiposEvento BuscarPorId(Guid id);

        /// <summary>
        /// Método responsável por atualizar um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEvento">objeto com os novos dados para atualizar</param>
        void Atualizar(Guid id, TiposEvento tipoEvento);
    }
}
