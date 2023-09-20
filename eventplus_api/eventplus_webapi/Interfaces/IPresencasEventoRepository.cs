using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface que define os métodos da entidade PresencasEvento
    /// </summary>
    public interface IPresencasEventoRepository
    {
        /// <summary>
        /// Método responsável por cadastrar uma nova Presença
        /// </summary>
        /// <param name="presencasEvento">Objeto com os atributos a serem cadastrados</param>
        void Cadastrar(PresencasEvento presencasEvento);

        /// <summary>
        /// Método responsável por listar todas as presenças
        /// </summary>
        /// <returns>Retorna uma lista com todas as presenças</returns>
        List<PresencasEvento> Listar();

        /// <summary>
        /// Método responsável por atualizar uma presença
        /// </summary>
        /// <param name="id">ID da presença que será atualizada</param>
        /// <param name="presencasEvento">objeto com os novos valores a serem adicionados</param>
        void Atualizar(Guid id, PresencasEvento presencasEvento);

        /// <summary>
        /// Método que é responsável por deletar
        /// </summary>
        /// <param name="id">ID da presença que será deletada</param>
        void Deletar(Guid id);

        /// <summary>
        /// Método responsável por listar as presenças de um determinado usuário
        /// </summary>
        /// <param name="idUsuario">As presenças serão buscadas a partir do ID do usuário</param>
        /// <returns>Retorna a lista filtrada</returns>
        List<PresencasEvento> ListarPresencasUser(Guid idUsuario);
    }
}
