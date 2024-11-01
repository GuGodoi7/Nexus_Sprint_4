using _Nexus.Models;
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
        /// Create a new task
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] UsuarioRequest request)
        {
            var usuario = new UsuarioModel
            {
                NomeUsuario = request.NomeUsuario,
                CPF = request.CPF,
                Telefone = request.Telefone,
                Email = request.Email
            };

            usuario.SetPassword(request.Password); 

            _userUseCase.AddTask(usuario);

            return Created();
        }


        /// <summary>
        /// Retrieves all tasks
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<IEnumerable<UsuarioModel>> GetAll()
        {
            var usuarios = _userUseCase.GetAllTasks();

            return Ok(usuarios);
        }

        /// <summary>
        /// Retrieves a specific task by ID
        /// </summary>

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<UsuarioModel> GetById(string id)
        {
            var usuario = _userUseCase.GetTaskById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        /// <summary>
        /// Deletes a task by id
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(string id)
        {
            var taskToDelete = _userUseCase.GetTaskById(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _userUseCase.DeleteTask(id);

            return NoContent();
        }


        /// <summary>
        /// Updates an existing task
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] UsuarioRequest request)
        {
            var taskToUpdate = _userUseCase.GetTaskById(id);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            taskToUpdate.NomeUsuario = request.NomeUsuario;
            taskToUpdate.CPF = request.CPF;
            taskToUpdate.PasswordHash = request.Password;
            taskToUpdate.Email = request.Email;
            taskToUpdate.Telefone = request.Telefone;

            _userUseCase.UpdateTask(taskToUpdate);

            return NoContent();
        }

        /// <summary>
        /// Cadastro de like em um determinado produto
        /// </summary>
        /// <param name="userLike"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("likeuser")]
        public async Task<IActionResult> PostUserLikeAsync([FromBody] UsuarioLike userLike)
        {
            _userUseCase.LikedUser(userLike);

            return Created();
        }

    }
}
