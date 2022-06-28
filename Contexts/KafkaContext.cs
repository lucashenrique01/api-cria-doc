using Confluent.Kafka;
using api_cria_doc.Models;
using System.Net;

namespace api_cria_doc.Contexts
{
    public class KafkaContext
    {
        public string GetTopic(){
            if(Environment.GetEnvironmentVariable("KAFKA_TOPIC") != null){
                return Environment.GetEnvironmentVariable("KAFKA_TOPIC");
            }
            return "br.com.example.correctTopic";
        }

        public ProducerConfig ConfigProducer(){
            var config = new ProducerConfig {
            BootstrapServers = "localhost:9092",            
            ClientId = Dns.GetHostName(),            
            };
            return config;
        }
        public ConsumerConfig configConsumer(){
            var config = new ConsumerConfig            
            {                
                BootstrapServers = "localhost:9092",                
                GroupId = "foo",                
                AutoOffsetReset = AutoOffsetReset.Earliest            
            }; 
            return config;
        }
        
    }
}