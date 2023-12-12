using eventplus_webapi.Domains;
using eventplus_webapi.Interfaces;
using eventplus_webapi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eventplus_webapi.Controllers
{
    /// <summary>
    /// Controlador com os Endpoints da entidade ComentarioEvento
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEventoRepository _comentarioEventoRepository;

        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que instancia o objeto do repositório
        /// </summary>
        public ComentarioEventoController(ContentModeratorClient contentModeratorClient)
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
            _contentModeratorClient = contentModeratorClient;
        }

        /// <summary>
        /// Endpoint que acessa o método cadastrar do ComentarioEventoRepository
        /// </summary>
        /// <param name="comentarioEvento">Objeto com os atributos a serem cadastrados</param>
        /// <returns>retorna um status code 200 - OK</returns>
        [HttpPost]
        public IActionResult Post(ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(comentarioEvento);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Listar do ComentarioEventoRepository
        /// </summary>
        /// <param name="idEvento">ID do evento que terá seus comentários listados</param>
        /// <returns>retorna um status code ok -200 com uma lista dos objetos</returns>
        [HttpGet("Evento/{idEvento}")]
        public IActionResult GetByIdEvento(Guid idEvento)
        {
            try
            {
                return Ok(_comentarioEventoRepository.Listar(idEvento));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarPorUsuario do repositório ComentarioEventoRepository
        /// </summary>
        /// <param name="idUsuario">ID do usuário que terá seus comentários listados</param>
        /// <returns>retorna um status code Ok - 200 com os objetos listados</returns>
        [HttpGet("Usuario")]
        public IActionResult GetByIdUsuario(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(_comentarioEventoRepository.ListarPorUsuario(idUsuario, idEvento));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método ListarTodos do ComentarioEventoRepository
        /// </summary>
        /// <returns>Retorna a lista com os objetos</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_comentarioEventoRepository.ListarTodos());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetExibe()
        {
            try
            {
                return Ok(_comentarioEventoRepository.ListarSomenteExibe());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método BuscarPorId do ComentarioEventoRepository
        /// </summary>
        /// <param name="id">ID do comentário que será buscado</param>
        /// <returns>retorna um statis code Ok com o objeto encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentarioEventoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Deletar do COmentarioEventoRepository
        /// </summary>
        /// <param name="id">ID do comentário que será deletado</param>
        /// <returns>Retorna um status code Ok - 200</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost("ComentarioIA")]
        public async Task<IActionResult> PostIA(ComentarioEvento comentario)
        {
            try
            {
                if ((comentario.Descricao).IsNullOrEmpty())
                {
                    return BadRequest("O comentário não pode estar vazio ou nulo!");
                }

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(comentario.Descricao!));

                var moderationResult = await _contentModeratorClient.TextModeration.ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                if (moderationResult.Terms != null)
                {
                    comentario.Exibe = false;

                    _comentarioEventoRepository.Cadastrar(comentario);
                }
                else
                {
                    comentario.Exibe= true;

                    _comentarioEventoRepository.Cadastrar(comentario);
                }
                return StatusCode(201, comentario);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


    }
}
