using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador com os endpoints da entidade PresencasEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencasEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presecasEventoRepository;

        /// <summary>
        /// Construtor responsável por instanciar um objeto do repository
        /// </summary>
        public PresencasEventoController()
        {
            _presecasEventoRepository = new PresencasEventoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método cadastrar no PresencasEventoRepository
        /// </summary>
        /// <param name="presencasEvento">objeto que contem as informações que serão cadastradas</param>
        /// <returns>Retorna um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(PresencasEvento presencasEvento)
        {
            try
            {
                _presecasEventoRepository.Cadastrar(presencasEvento);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar no PresencasEventoRepository
        /// </summary>
        /// <returns>Retorna um StatusCode 200 - OK com a lista de objetos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_presecasEventoRepository.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarPresencasUser do PresencasEventoRepository
        /// </summary>
        /// <param name="id">ID do usuário que terá as suas presenças listadas</param>
        /// <returns>retorna um statuscode OK- 200 com a lista de objetos</returns>
        [HttpGet("{id}")]
        public IActionResult GetByUser(Guid id)
        {
            try
            {
                return Ok(_presecasEventoRepository.ListarPresencasUser(id));

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar do PresencaEventoRepository
        /// </summary>
        /// <param name="id">ID da presença que será atualizada</param>
        /// <param name="presencaEvento">Objeto com os novos valores</param>
        /// <returns>Retorna um status code 200 - ok</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencasEvento presencaEvento)
        {
            try
            {
                _presecasEventoRepository.Atualizar(id, presencaEvento);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar da PresencaEventoRepository
        /// </summary>
        /// <param name="id">ID da prensença que será deletada</param>
        /// <returns>Retorna um status code 200 - ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presecasEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
