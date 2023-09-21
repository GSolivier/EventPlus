using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório responsável por armazenar os métodos implementados pela Interface IInstituicaoRepository
    /// </summary>
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _eventContext;

        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        /// <summary>
        /// Método para cadastrar uma nova instituição no sistema
        /// </summary>
        /// <param name="instituicao">Objeto com os valores a serem cadastrados</param>
        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                _eventContext.Add(instituicao);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
