using Confluent.Kafka;
using System.Net;

namespace api_cria_doc.Contexts
{
    public class KafkaContext
    {
        public string GetTopic(){
            if(Environment.GetEnvironmentVariable("KAFKA_TOPIC") != null){
                return Environment.GetEnvironmentVariable("KAFKA_TOPIC");
            }
            return "br.com.example.document.created";
        }

        public string GetBroker(){
            if(Environment.GetEnvironmentVariable("BROKER_HOST") != null){
                return Environment.GetEnvironmentVariable("BROKER_HOST");
            }
            return "localhost:9092";
        }

        public ProducerConfig ConfigProducer(){
            var config = new ProducerConfig {
            BootstrapServers = GetBroker(),            
            ClientId = Dns.GetHostName(),            
            };
            return config;
        }
        public ConsumerConfig configConsumer(){
            var config = new ConsumerConfig            
            {                
                BootstrapServers = GetBroker(),                
                GroupId = "foo",                
                AutoOffsetReset = AutoOffsetReset.Earliest            
            }; 
            return config;
        }
        
    }
}