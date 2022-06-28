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
            { host = Environment.GetEnvironmentVariable("MONGO_HOST"); } 
            else { 
                return host = "mongodb://localhost:27017"; 
                } 
            return host; 
        }
        public string GetDatabase() { 
            string database; 
            if (Environment.GetEnvironmentVariable("MONGO_DATABASE") != null) { 
                database = Environment.GetEnvironmentVariable("MONGO_DATABASE"); 
            } else { return database = "cria-doc"; 
            } 
            return database; 
        }
    }
}