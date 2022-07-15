using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using api_cria_doc.Models;

namespace api_cria_doc.Converters
{
    public class BsonToObject
    {
        public Document convertToObject(BsonDocument bson)
		{
			Document document = new Document();
			document = BsonSerializer.Deserialize<Document>(bson);
			return document;
		}
    }
}