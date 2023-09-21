using eventplus_webapi.Contexts;
using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Utils;
using Microsoft.EntityFrameworkCore;

namespace eventplus_webapi.Repositories
{
    /// <summary>
    /// Repositório que define a ógica dos métodos implementados pela Interface IUsuarioRepository
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext _eventContext;

        /// <summary>
        /// Construtor que instancia o objeto
        /// </summary>
        public UsuarioRepository()
        {
            _eventContext = new EventContext();
        }

        /// <summary>
        /// Método responsável por buscar um usuário pelo seu email e senha
        /// </summary>
        /// <param name="email">email que será fornecido pelo usuário</param>
        /// <param name="senha">senha que será fornecida pelo usuário</param>
        /// <returns>retorna o objeto encontrado</returns>
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _eventContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         IdTipoUsuario = u.IdTipoUsuario,
                         Nome = u.Nome,
                         Email = u.Email,
                         Senha = u.Senha,
                         TiposUsuario = new TiposUsuario
                         {
                             Titulo = u.TiposUsuario!.Titulo
                         }
                     }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por buscar um usuário pelo seu ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>retorna o objeto encontrado</returns>
        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuario = _eventContext.Usuario
                     .Select(u => new Usuario
                     {
                         IdUsuario = u.IdUsuario,
                         Nome = u.Nome,
                         TiposUsuario = new TiposUsuario
                         {
                             Titulo = u.TiposUsuario!.Titulo
                         }
                     }).FirstOrDefault(u => u.IdUsuario == id)!;

                if (usuario != null)
                {
                    return usuario;
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Método responsável por cadastrar um novo usuário
        /// </summary>
        /// <param name="usuario">objeto com os novos atributos a serem cadastrados</param>
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                _eventContext.Usuario.Add(usuario);

                _eventContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
