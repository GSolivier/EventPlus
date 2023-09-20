using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da entidade Instituição
    /// </summary>
    public interface IInstituicao
    {
        /// <summary>
        /// Método para cadastrar uma nova instituição no sistema
        /// </summary>
        /// <param name="instituicao">Objeto com os valores a serem cadastrados</param>
        void Cadastrar(Instituicao instituicao);
    }
}
