using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade ComentarioEvento
    /// </summary>
    public interface IComentarioEventoRepository
    {
        /// <summary>
        /// Método para cadastrar um novo comentário
        /// </summary>
        /// <param name="comentarioEvento">Objeto com os valores a serem cadastrados</param>
        void Cadastrar(ComentarioEvento comentarioEvento);

        /// <summary>
        /// Método para listar todos os comentários daquele evento
        /// </summary>
        /// <returns> Retorna a lista dos comentários</returns>
        List<ComentarioEvento> Listar(Guid idEvento);

        /// <summary>
        /// Método para deletar um comentário existente
        /// </summary>
        /// <param name="id"> ID do comentário que será deletado </param>
        void Deletar(Guid id);

        /// <summary>
        /// Método para buscar um comentário por ID
        /// </summary>
        /// <param name="id">ID do comentário que será buscado</param>
        /// <returns>Retorna o objeto com o comentário buscado</returns>
        ComentarioEvento BuscarPorId(Guid id);

        /// <summary>
        /// Lista todos os comentários de um determindado usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário que terá os seus comentários listados</param>
        /// <returns>Uma lista com os comentários do usuário</returns>
        ComentarioEvento ListarPorUsuario(Guid idUsuario, Guid idEvento);

        /// <summary>
        /// Método para listar todos os comentários
        /// </summary>
        /// <returns>retorna uma lista com os objetos</returns>
        List<ComentarioEvento> ListarTodos();

        List<ComentarioEvento> ListarSomenteExibe();
    }
}
