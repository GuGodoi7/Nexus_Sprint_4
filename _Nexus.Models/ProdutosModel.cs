using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace _Nexus.Models
{
    [Collection("NX_PRODUTOS")]
    public class ProdutosModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("nome")]
        [Required]
        public string Nome { get; set; }

        [BsonElement("preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        [Required]
        public decimal Preco { get; set; }

        [BsonElement("stock")]
        [Required]
        public int Stock { get; set; }

        [BsonElement("descricao")]
        public string Descricao { get; set; }

        [BsonElement("categoria")]
        [Required]
        public string Categoria { get; set; }

        [BsonElement("createdAt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}