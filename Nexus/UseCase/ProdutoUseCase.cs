using _Nexus.Models;
using _Nexus.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

namespace Nexus.UseCase
{
    public class ProdutoUseCase
    {
        private readonly IRepository<ProdutosModel> _produtoRepository;

        public ProdutoUseCase(IRepository<ProdutosModel> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutosModel> GetAllTasks()
        {
            return _produtoRepository.GetAll();
        }

        public ProdutosModel GetTaskById(string id)
        {
            return _produtoRepository.GetById(id);
        }

        public void AddTask(ProdutosModel produtos)
        {
            if (string.IsNullOrEmpty(produtos.Id))
            {
                produtos.Id = ObjectId.GenerateNewId().ToString();
            }

            _produtoRepository.Add(produtos);
        }

        public void UpdateTask(ProdutosModel produtos)
        {
            _produtoRepository.Update(produtos);
        }

        public void DeleteTask(string id)
        {
            _produtoRepository.Delete(id);
        }
    }
}
