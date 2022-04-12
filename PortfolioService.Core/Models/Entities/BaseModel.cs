using MongoDB.Bson.Serialization.Attributes;

namespace PortfolioService.Core.Models.Entities
{
    public class BaseModel
    {
        [BsonElement("isDeleted")]
        public bool IsDeleted { get; set; }
    }
}
