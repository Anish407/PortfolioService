using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PortfolioService.Core.Models.Entities;

namespace CodeTest.Infrastructure.Models
{
    public class PortfolioData: BaseModel
    {
        [BsonElement("id")]
        public ObjectId Id { get; set; }
        [BsonElement("currentTotalValue")]
        public float CurrentTotalValue { get; set; }
        [BsonElement("stocks")]
        public ICollection<StockData> Stocks { get; set; } = new List<StockData>();
    }
}