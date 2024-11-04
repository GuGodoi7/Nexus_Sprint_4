namespace _Nexus.Services.MLRecommendationService
{
    public class ProductRating
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public float Label { get; set; }
    }
}
