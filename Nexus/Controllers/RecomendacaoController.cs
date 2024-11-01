using _Nexus.Models;
using _Nexus.Repository.Interface;
using _Nexus.Services.MLRecommendationService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Nexus.Controllers
{
    [ApiController]
    [Route("api/Recomendacao")]
    [Tags("Recomendação")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationEngine _recommendationEngine;
        private readonly IRepository<ProdutosModel> _productRepository;
        private readonly IRepository<UsuarioLike> _userLikeRepository;

        public RecommendationController(RecommendationEngine recommendationEngine, IRepository<ProdutosModel> productRepository, IRepository<UsuarioLike> userLikeRepository)
        {
            _recommendationEngine = recommendationEngine;
            _productRepository = productRepository;
            _userLikeRepository = userLikeRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetRecommendations(string userId)
        {
            _recommendationEngine.PreparingandTrainModel(_userLikeRepository.GetAll());


            if (!ObjectId.TryParse(userId, out ObjectId parsedUserId))
            {
                return BadRequest("Invalid user ID");
            }

            var products = _productRepository.GetAll();
            var recommendedProducts = new List<ProdutosModel>();

            foreach (var product in products)
            {
                if (!ObjectId.TryParse(product.Id.ToString(), out ObjectId parsedProductId))
                {
                    continue;
                }

                float score = _recommendationEngine.Predict(parsedUserId, parsedProductId);

                if (score > 0.5)
                {
                    recommendedProducts.Add(product);
                }
            }

            return Ok(recommendedProducts);
        }
    }
}

