using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeTest.Infrastructure.Models
{
    public class StockData
    {
        [BsonElement("ticker")]
        public string Ticker { get; set; }
        [BsonElement("baseCurrency")]
        public string BaseCurrency { get; set; }
        [BsonElement("numberOfShares")]
        public int NumberOfShares { get; set; }
    }
}