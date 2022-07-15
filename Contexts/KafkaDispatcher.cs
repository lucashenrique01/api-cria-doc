using Confluent.Kafka;
using Newtonsoft.Json.Linq;

namespace api_cria_doc.Contexts
{
    public class KafkaDispatcher
    {
        KafkaContext kafkaContext = new KafkaContext();
        public void Producer(string value, string id, string topic){
            using (var producer = new ProducerBuilder<string, string>(kafkaContext.ConfigProducer()).Build())
            {                   
                
                try{
                    producer.Produce(topic, new Message<string, string> {Key= $"{id}",Value = $"{value}"},
                    (deliveryReport) =>
                    {
                        if (deliveryReport.Error.Code != ErrorCode.NoError) {
                            Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                        }
                        else {
                            Console.WriteLine($"Produced event to topic {topic}: key = {id} value = {value}");                            
                            Console.WriteLine(value);                    
                            Console.WriteLine("Event created");
                        }
                    });
                    producer.Flush(TimeSpan.FromSeconds(10));                    
                }catch(Exception ex){
                    Console.Write(ex);
                }              
                         
            }        
        }
    }
}