using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável por definir os métodos da entidade Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">objeto com os novos atributos a serem cadastrados</param>
        void Cadastrar(Usuario usuario);

        /// <summary>
        /// Método responsável por buscar um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Método responsável por buscar um usuário pelo seu email e senha
        /// </summary>
        /// <param name="email">email que será fornecido pelo usuário</param>
        /// <param name="senha">senha que será fornecida pelo usuário</param>
        /// <returns>retorna o objeto encontrado</returns>
        Usuario BuscarPorEmailESenha(string email, string senha);
    }
}
