using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório com os métodos implementados pela Interface
    /// </summary>
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor que instancia o objeto
        /// </summary>
        public TiposUsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Método responsável por cadastrar um novo tipo de usuário no sistema
        /// </summary>
        /// <param name="tipoUsuario">objeto com os atributos que serão atualizados</param>
        public void Cadastrar(TiposUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TiposUsuario.Add(tipoUsuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Método responsável por listar todos os tipos de usuário
        /// </summary>
        /// <returns>retorna a lista com todos os tipos de usuário</returns>
        public List<TiposUsuario> Listar()
        {
            try
            {
                return _eventContext.TiposUsuario.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por atualizar um tipo de usuário existente
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será atualizado</param>
        /// <param name="tipoUsuario">objeto que contém os atributos que serão atualizados</param>
        public void Atualizar(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = BuscarPorId(id);

                tipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;

                _eventContext.TiposUsuario.Update(tipoUsuarioBuscado);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            try
            {
                TiposUsuario tipoUsuarioBuscado = _eventContext.TiposUsuario.FirstOrDefault(tp => tp.IdTipoUsuario == id)!;

                if (tipoUsuarioBuscado == null)
                {
                    throw new Exception($"Tipo de usuário com o ID {id} não encontrado");
                }

                return tipoUsuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
