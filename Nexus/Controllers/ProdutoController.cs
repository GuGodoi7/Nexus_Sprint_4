using _Nexus.Models;
using Microsoft.AspNetCore.Mvc;
using Nexus.UseCase;
using System.Net;

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
        /// Retorna todos os produto
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
        /// Retorna um produto específico pelo ID
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<Task> GetById(string id)
        {
            var task = _produtoUseCase.GetProdutosById(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        /// <summary>
        /// Cadastro de produto
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] ProdutoRequest request)
        {

            var produto = new ProdutosModel
            {
                Nome = request.Nome,
                Categoria = request.Categoria,
                Descricao = request.Descricao,
                Preco = request.Preco,
                Stock = request.Stock
            };

            _produtoUseCase.AddProdutos(produto);

            return Created();
        }

        /// <summary>
        /// Atualiza um produto pelo ID
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] ProdutoRequest request)
        {
            var taskToUpdate = _produtoUseCase.GetProdutosById(id);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            taskToUpdate.Nome = request.Nome;
            taskToUpdate.Categoria = request.Categoria;
            taskToUpdate.Descricao = request.Descricao;
            taskToUpdate.Preco = request.Preco;
            taskToUpdate.Stock = request.Stock;

            _produtoUseCase.UpdateProdutos(taskToUpdate);

            return NoContent();
        }

        /// <summary>
        /// Exclui um produto pelo ID
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(string id)
        {
            var taskToDelete = _produtoUseCase.GetProdutosById(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _produtoUseCase.DeleteProdutos(id);

            return NoContent();
        }

    }
}