using _Nexus.Models;
using _Nexus.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Nexus.UseCase;
using System.Net;
using System.Threading.Tasks;

namespace Nexus.Controllers
{
    [ApiController]
    [Route("api/Produtos")]
    [Tags("Produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoUseCase _produtoUseCase;

        public ProdutoController(ProdutoUseCase produtoUseCase)
        {
            _produtoUseCase = produtoUseCase;
        }

        /// <summary>
        /// Retrieves all tasks
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<IEnumerable<ProdutosModel>> GetAll()
        {
            var tasks = _produtoUseCase.GetAllTasks();

            return Ok(tasks);
        }

        /// <summary>
        /// Retrieves a specific task by ID
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<ProdutosModel> GetById(string id)
        {
            var task = _produtoUseCase.GetTaskById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] ProdutoRequest request)
        {
            var produtos = new ProdutosModel
            {
                Nome = request.Nome,
                Categoria = request.Categoria,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Stock = request.Stock
            };

            _produtoUseCase.AddTask(produtos);

            return Created();
        }

        /// <summary>
        /// Updates an existing task
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] ProdutoRequest request)
        {
            var produtoToUpdate = _produtoUseCase.GetTaskById(id);

            if (produtoToUpdate == null)
            {
                return NotFound();
            }

            produtoToUpdate.Nome = request.Nome;
            produtoToUpdate.Categoria = request.Categoria;
            produtoToUpdate.Descricao = request.Descricao;
            produtoToUpdate.Stock = request.Stock;
            produtoToUpdate.Preco = request.Preco;


            _produtoUseCase.UpdateTask(produtoToUpdate);

            return NoContent();
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
            var taskToDelete = _produtoUseCase.GetTaskById(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _produtoUseCase.DeleteTask(id);

            return NoContent();
        }

    }
}