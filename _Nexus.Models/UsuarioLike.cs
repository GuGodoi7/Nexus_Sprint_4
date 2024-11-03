using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace _Nexus.Models
{
    [Collection("NX_USERLIKE")]
    public class UsuarioLike
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        public DateTime LikedAt { get; set; } = DateTime.UtcNow;

    }
}