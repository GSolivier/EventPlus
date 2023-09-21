using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador para armazenar os métodos da entidade TiposEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TiposEventoController : ControllerBase
    {
        private ITiposEventoRepository _tiposEventoRepository;

        /// <summary>
        /// controlador para instanciar um novo repositório de evento
        /// </summary>
        public TiposEventoController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// Endpoint para realizar um cadastro de um novo tipo de evento a partir do repository
        /// </summary>
        /// <param name="tipoEvento">o objeto com os novos atributos a serem passados pelo usuário</param>
        /// <returns>retorna um status code(201) - Created </returns>
        [HttpPost]
        public IActionResult Post(TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Cadastrar(tipoEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de Listar na TiposEventoRepository
        /// </summary>
        /// <returns>Retorna um status code 200 - ok com a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposEventoRepository.Listar());
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint que aciona o método Atualizar na tipoEventoRepository
        /// </summary>
        /// <param name="id">ID do objeto que será atualizado</param>
        /// <param name="tipoEvento">corpo do objeto com as novas informações</param>
        /// <returns>Retorna um status code Ok - 200</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TiposEvento tipoEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tipoEvento);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do TipoEventoRepository
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        /// <returns>Retorna um status code OK - 200</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId no tiposEventoRepoistory
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>Retorna um status code Ok com o objeto encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TiposEvento tipoEventoBuscado = _tiposEventoRepository.BuscarPorId(id);

                return Ok(tipoEventoBuscado);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
