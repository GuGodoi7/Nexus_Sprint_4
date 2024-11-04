using _Nexus.Models;
using _Nexus.Repository.Interface;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;

namespace Nexus.UseCase
{
    public class ProdutoUseCase
    {
        private readonly IRepository<ProdutosModel> _ProdutoRepository;

        public ProdutoUseCase(IRepository<ProdutosModel> ProdutoRepository)
        {
            _ProdutoRepository = ProdutoRepository;
        }

        public IEnumerable<ProdutosModel> GetAllProdutos()
        {
            return _ProdutoRepository.GetAll();
        }

        public ProdutosModel GetProdutosById(string id)
        {
            return _ProdutoRepository.GetById(id);
        }

    public void AddProdutos(ProdutosModel produto)
    {
        if (produto.Id == ObjectId.Empty) 
        {
            produto.Id = ObjectId.GenerateNewId(); 
        }

        _ProdutoRepository.Add(produto);
    }

        public void UpdateProdutos(ProdutosModel produto)
        {
            _ProdutoRepository.Update(produto);
        }

        public void DeleteProdutos(string id)
        {
            _ProdutoRepository.Delete(id);
        }
    }
}
