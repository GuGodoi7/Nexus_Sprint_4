using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Nexus.Services.MLRecommendationService
{
    public class ProductRating
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public float Label { get; set; }
    }
}
