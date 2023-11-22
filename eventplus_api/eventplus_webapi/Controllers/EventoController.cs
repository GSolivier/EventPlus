using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador responsável pelos Endpoits da entidade Evento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        /// <summary>
        /// Constutor que instancia o objeto do _eventoRepository
        /// </summary>
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar na EventoRepository
        /// </summary>
        /// <param name="evento">Objeto com os atributos a serem cadastrados</param>
        /// <returns>retorna um StatusCode OK - 200</returns>
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar na EventoRepository
        /// </summary>
        /// <returns>Retorna um StatusCode Ok - 200 com a lista de eventos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarProximos do EventoRepository
        /// </summary>
        /// <returns>Retorna um StatusCode Ok - 200 com a lista de objetos</returns>
        [HttpGet("ListarProximos")]
        public IActionResult GetNext()
        {
            try
            {
                return Ok(_eventoRepository.ListarProximos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Atualizar na EventoRepository
        /// </summary>
        /// <param name="id">ID do objeto que será atualizado</param>
        /// <param name="evento">corpo do objeto com as novas informações</param>
        /// <returns>Retorna um StatusCode Ok - 200</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do Repository
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        /// <returns>retorna um status code ok - 200</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId do eventoRepository
        /// </summary>
        /// <param name="id">ID do objeto que será buscado</param>
        /// <returns>Retorna um statusCode Ok - 200</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_eventoRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
