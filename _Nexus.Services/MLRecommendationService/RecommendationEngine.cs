using _Nexus.Models;
using Microsoft.ML;
using MongoDB.Bson;
using System.Collections.Generic;

namespace _Nexus.Services.MLRecommendationService
{
    public class RecommendationEngine
    {
        private readonly MLContext _mlContext = new MLContext();
        private ITransformer _model;

        public void TrainModel(IEnumerable<UsuarioLike> allUserLikes)
        {
            var productRatings = new List<ProductRating>();

            foreach (var like in allUserLikes)
            {
                productRatings.Add(new ProductRating
                {
                    UserId = like.UserId.ToString(),
                    ProductId = like.ProductId.ToString(),
                    Label = 1
                });
            }

            Train(productRatings);
        }

        private void Train(List<ProductRating> productRatings)
        {
            var trainingData = _mlContext.Data.LoadFromEnumerable(productRatings);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("userIdEncoded", nameof(ProductRating.UserId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("productIdEncoded", nameof(ProductRating.ProductId)))
                .Append(_mlContext
                    .Recommendation()
                    .Trainers
                    .MatrixFactorization(
                        labelColumnName: nameof(ProductRating.Label),
                        matrixColumnIndexColumnName: "userIdEncoded",
                        matrixRowIndexColumnName: "productIdEncoded")
                );

            _model = pipeline.Fit(trainingData);
        }

        public float Predict(ObjectId userId, ObjectId productId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductRating, CategoryPrediction>(_model);

            var prediction = predictionEngine.Predict(new ProductRating
            {
                UserId = userId.ToString(),
                ProductId = productId.ToString()
            });

            return prediction.Score;
        }

        public void PreparingandTrainModel(IEnumerable<UsuarioLike> enumerable)
        {
            throw new NotImplementedException();
        }
    }

    public class CategoryPrediction
    {
        public float Score { get; set; }
    }
}
