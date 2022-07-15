using Confluent.Kafka;
using api_cria_doc.Services;
using api_cria_doc.Converters;
using api_cria_doc.DTO;

namespace api_cria_doc.Contexts
{
    public class KafkaConsumer
    {   
        
        KafkaContext kafkaContext = new KafkaContext();
        DocumentService documentService = new DocumentService();

        public void Consumer(){            
            CancellationTokenSource cts = new CancellationTokenSource();            
            Console.CancelKeyPress += (_, e) =>            
            {                
                e.Cancel = true;                
                cts.Cancel();            
            };
            string topic = "br.com.example.orchestrator.cancel";
                       
            using (var consumer = new ConsumerBuilder<Ignore, string>(kafkaContext.configConsumer()).Build())            
            {                
                consumer.Subscribe(topic);
                while(true){                    
                    var a = consumer.Consume(cts.Token);     
                    EventDto eventDto = EventConverter.jsonToEvent(a.Message.Value);
                    documentService.DeleteDocument(eventDto.data.idDocument);
                    Console.WriteLine(a.Message.Value);            
                }                            
            }        
        }
    }
}