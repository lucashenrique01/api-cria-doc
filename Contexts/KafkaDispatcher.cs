using Confluent.Kafka;


namespace api_cria_doc.Contexts
{
    public class KafkaDispatcher
    {
        KafkaContext kafkaContext = new KafkaContext();
        public void Producer(string value){
            using (var producer = new ProducerBuilder<Null, string>(kafkaContext.ConfigProducer()).Build())
            {                   
                
                try{
                    producer.Produce(kafkaContext.GetTopic(), new Message<Null, string> {Value = $"{value}"});
                }catch(Exception ex){
                    Console.Write(ex);
                }              
                           
            }        
        }
    }
}