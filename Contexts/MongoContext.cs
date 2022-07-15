using MongoDB.Driver;
namespace api_cria_doc.Contexts
{
    public class MongoContext
    {
        public MongoClient Connectdb(string host)
        {
            MongoClient dbClient = new MongoClient($"{host}");
            return dbClient;
        }
        public string GetHostMongo() { 
            string host; 
            if (Environment.GetEnvironmentVariable("MONGO_HOST") != null) 
            { 
               return host = Environment.GetEnvironmentVariable("MONGO_HOST"); 
            }
            return host = "mongodb://localhost:27017";
        }
        public string GetDatabase() { 
            string database; 
            if (Environment.GetEnvironmentVariable("MONGO_DATABASE") != null) { 
               return database = Environment.GetEnvironmentVariable("MONGO_DATABASE"); 
            }  
            return database = "create-doc";
        }

        public string GetCollection(){
            string collection;
            if(Environment.GetEnvironmentVariable("MONGO_COLLECTION") != null){
                return collection = Environment.GetEnvironmentVariable("MONGO_COLLECTION");
            }
            return collection = "documents";
        }
    }
}