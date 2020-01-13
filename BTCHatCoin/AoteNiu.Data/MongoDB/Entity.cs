using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AoteNiu.Data
{
    //
    // 摘要:
    //     Abstract Entity for all the BusinessEntities.
    [BsonIgnoreExtraElements(Inherited = true)]
    [System.Runtime.Serialization.DataContractAttribute]
    public abstract class Entity : IEntity<string>
    {
        //protected void Entity();

        //
        // 摘要:
        //     Gets or sets the id for this object (the primary record for an entity).
        [BsonRepresentation(BsonType.ObjectId)]
        [System.Runtime.Serialization.DataMemberAttribute]
        public virtual string Id { get; set; }
    }
}
