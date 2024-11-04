using _Nexus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nexus.UseCase;
using System.Net;

namespace Nexus.Controllers
{
   
    [ApiController]
    [Route("api/usuario")]
    [Tags("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioUseCase _userUseCase;

        public UsuarioController(UsuarioUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }

        /// <summary>
        /// Cadastro de Usu�rios
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] UsuarioRequest userRequest)
        {
            if (userRequest == null)
                return BadRequest("Dados do usu�rio n�o podem ser nulos.");

            try
            {
                _userUseCase.CreateUser(userRequest);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao criar usu�rio.");
            }
        }

        /// <summary>
        /// Retorna todos os usu�rios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get()
        {
            try
            {
                var users = _userUseCase.GetUsers();
                return Ok(users);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao recuperar usu�rios.");
            }
        }

        /// <summary>
        /// Retorna um usu�rio espec�fico pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("O ID do usu�rio n�o pode ser nulo ou vazio.");
            }

            // Log o ID recebido
            Console.WriteLine($"Buscando usu�rio com ID: {id}");

            try
            {
                var user = _userUseCase.GetUserById(id);
                if (user == null)
                {
                    return NotFound("Usu�rio n�o encontrado.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        /// <summary>
        /// Atualiza um usu�rio pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(string id, [FromBody] UsuarioRequest userRequest)
        {
            if (userRequest == null)
                return BadRequest("Dados do usu�rio n�o podem ser nulos.");

            try
            {
                var userExists = _userUseCase.GetUserById(id);
                if (userExists == null)
                    return NotFound("Usu�rio n�o encontrado.");

                _userUseCase.UpdateUser(id, userRequest);
                return NoContent();
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao atualizar usu�rio.");
            }
        }

        /// <summary>
        /// Exclui um usu�rio pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(string id)
        {
            try
            {
                _userUseCase.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        }

        /// <summary>
        /// Cadastro de like em um determinado usu�rio
        /// </summary>
        /// <param name="userLike"></param>
        /// <returns></returns>
        [HttpPost("likeuser")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult PostUserLike([FromBody] UsuarioLike userLike)
        {
            if (userLike == null)
                return BadRequest("Dados do like n�o podem ser nulos.");

            try
            {
                _userUseCase.LikedUser(userLike);
                return StatusCode((int)HttpStatusCode.Created);
            }
            catch
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Erro ao registrar like.");
            }
        }
    }
}
