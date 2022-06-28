using api_cria_doc.Contexts;
using api_cria_doc.Models;
using MongoDB.Driver;
using Confluent.Kafka;
  
namespace api_cria_doc.DAO
{
    public class DocumentDao    
    {        
        KafkaContext kafkaContext = new KafkaContext();
        public void Insert(Document document){            
            MongoContext mongoContext = new MongoContext();            
            MongoClient client =  mongoContext.Connectdb(mongoContext.GetHostMongo());            
            var database = client.GetDatabase(mongoContext.GetDatabase());            
            var collection = database.GetCollection<Document>("documents");     
            try{
                collection.InsertOne(document); 
            }catch(Exception ex){
                Console.Write(ex);
            }                         
        }

        

        public void Consumer(){            
            CancellationTokenSource cts = new CancellationTokenSource();            
            Console.CancelKeyPress += (_, e) =>            
            {                
                e.Cancel = true;                
                cts.Cancel();            
            };
                       
            using (var consumer = new ConsumerBuilder<Ignore, string>(kafkaContext.configConsumer()).Build())            
            {                
                consumer.Subscribe(kafkaContext.GetTopic());
                while(true){                    
                    var a = consumer.Consume(cts.Token);                                    
                    Console.WriteLine(a.Message.Value);                
                }                            
            }        
        }
    }
}