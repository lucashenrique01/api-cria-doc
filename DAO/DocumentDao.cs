using api_cria_doc.Contexts;
using api_cria_doc.Models;
using MongoDB.Bson;  
using api_cria_doc.Converters;
using MongoDB.Driver;


  
namespace api_cria_doc.DAO
{
    public class DocumentDao    
    {        
        MongoContext mongo = new MongoContext();
        
        
        
        public void Insert(Document document){            
            MongoContext mongoContext = new MongoContext();            
            MongoClient client =  mongoContext.Connectdb(mongoContext.GetHostMongo());            
            var database = client.GetDatabase(mongoContext.GetDatabase());            
            var collection = database.GetCollection<Document>(mongoContext.GetCollection());     
            try{
                collection.InsertOne(document); 
                Console.WriteLine("Documento criado!");
            }catch(Exception ex){
                Console.Write(ex);
            }                         
        } 

        public void GetDocuments(){
            BsonToObject bsonToObject = new BsonToObject();    
            MongoClient dbClient = new MongoClient($"{mongo.GetHostMongo()}");        
            var database = dbClient.GetDatabase($"{mongo.GetDatabase()}"); 
            var collections = database.GetCollection<BsonDocument>($"{mongo.GetCollection()}");
            var documents = collections.Find(new BsonDocument()).ToList();
            for(int i = 0; i < documents.Count; i++)
            { 
                Console.WriteLine(documents[i]);                        
            }  
        }   

        public void DeleteDocumentByIdDocument(string id_document){
            MongoClient dbClient = new MongoClient($"{mongo.GetHostMongo()}");
            var database = dbClient.GetDatabase($"{mongo.GetDatabase()}"); 
            var collections = database.GetCollection<BsonDocument>($"{mongo.GetCollection()}");            
            var filtro = Builders<BsonDocument>.Filter.Eq("id_documento", id_document);
            var document = collections.Find(filtro);

            if(document != null){
                collections.DeleteOne(filtro); 
                Console.WriteLine($"Document {id_document} canceled");              
            }else {
                Console.WriteLine("Documento not exists");
            }
        }    
    }
}