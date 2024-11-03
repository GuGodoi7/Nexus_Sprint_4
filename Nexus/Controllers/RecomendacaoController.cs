using _Nexus.Models;
using _Nexus.Repository.Interface;
using _Nexus.Services.MLRecommendationService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

        /// <summary>
        /// Recomenda um produto 
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetRecommendations(string userId)
        {
            if (!ObjectId.TryParse(userId, out ObjectId parsedUserId))
            {
                return BadRequest("Invalid user ID");
            }

            var userLikes = _userLikeRepository.GetAll(); 
            var likedProducts = userLikes.Where(l => l.UserId == userId).ToList(); 

            if (!likedProducts.Any())
            {
                return NotFound("No liked products found for the user.");
            }


            _recommendationEngine.PreparingandTrainModel(userLikes);

            var recommendedProducts = new List<ProdutosModel>();

            foreach (var likedProduct in likedProducts)
            {

                if (ObjectId.TryParse(likedProduct.ProductId, out ObjectId productId))
                {

                    var product = _productRepository.GetAll().FirstOrDefault(p => p.Id == productId);

                    if (product != null)
                    {

                        var similarProducts = _productRepository.GetAll()
                            .Where(p => p.Categoria == product.Categoria) 
                            .ToList();

                        foreach (var similarProduct in similarProducts)
                        {
                            if (!likedProducts.Any(lp => lp.ProductId == similarProduct.Id.ToString()))
                            {
                                recommendedProducts.Add(similarProduct);
                            }
                        }
                    }
                }
            }

            return Ok(recommendedProducts.Distinct().ToList()); 
        }


    }
}
