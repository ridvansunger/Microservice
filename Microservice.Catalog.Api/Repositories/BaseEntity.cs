using MongoDB.Bson.Serialization.Attributes;

namespace Microservice.Catalog.Api.Repositories
{
    public class BaseEntity
    {
        //snow flake => index lemeyi kolaylaştırır
        [BsonElement("_id")] public Guid Id { get; set; }
    }
}
