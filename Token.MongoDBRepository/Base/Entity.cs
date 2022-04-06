using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCore.Base;
public abstract class Entity
{
    [BsonId]
    public ObjectId Id { get; set; }
}