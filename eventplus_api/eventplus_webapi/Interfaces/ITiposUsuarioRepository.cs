using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da entidade TiposUsuario
    /// </summary>
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo tipo de usuário no sistema
        /// </summary>
        /// <param name="tipoUsuario">objeto com os atributos que serão atualizados</param>
        void Cadastrar(TiposUsuario tipoUsuario);

        /// <summary>
        /// Método responsável por deletar um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método responsável por listar todos os tipos de usuário
        /// </summary>
        /// <returns>retorna a lista com todos os tipos de usuário</returns>
        List<TiposUsuario> Listar();

        /// <summary>
        /// Método responsável por buscar um tipo de usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do tipo do usuário que sera´buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        TiposUsuario BuscarPorId(Guid id);

        /// <summary>
        /// Método responsável por atualizar um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuario">objeto que contém os atributos que serão atualizados</param>
        void Atualizar(Guid id, TiposUsuario tipoUsuario);
    }
}
