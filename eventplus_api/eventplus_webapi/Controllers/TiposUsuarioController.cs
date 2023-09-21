using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador com os métodos para a entidade TipoUsuario
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tipoUsuarioRepository;

        /// <summary>
        /// Construtor para atribuir um novo objeto 
        /// </summary>
        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Endpoint que acessa o tipoUsuarioRepository para realizar um novo cadastro
        /// </summary>
        /// <param name="tiposUsuario">Objeto com os valores a serem cadastrados</param>
        /// <returns>Retorna um StatusCode(200) - Ok</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario tiposUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tiposUsuario);

                return Created("", tiposUsuario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar do tipoUsuarioRepository
        /// </summary>
        /// <returns>Retorna um status code 200 com a lista de tipos de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar do tipoUsuarioRepository
        /// </summary>
        /// <param name="id">ID do usuário que será atualizado</param>
        /// <param name="tipoUsuario">Objeto com os novos atributos a serem atualizados</param>
        /// <returns>Retorna um status code 200 - Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do TipoUsuarioRepository
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        /// <returns>Retorna um StatusCode 200 - Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método BuscarPorId no TipoUsuarioRepository
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>retorna um StatusCode Ok - 200 com o objeto encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
