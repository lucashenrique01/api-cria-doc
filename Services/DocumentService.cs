using api_cria_doc.Models;
using api_cria_doc.DAO;
using api_cria_doc.Contexts;
using Newtonsoft.Json.Linq;

namespace api_cria_doc.Services
{
    public class DocumentService
    {
        DocumentDao documentDao = new DocumentDao();
        KafkaDispatcher kafkaDispatcher = new KafkaDispatcher();


        //end-point de criação
        public void CreateDocument(){
            Assinante assinante1 = new Assinante("Lucas Henrique", "123456789");
            Assinante assinante2 = new Assinante("SPTECH", "00221145");
            Assinante assinante3 = new Assinante("BANCO SAFRA", "000655946");

            List<Assinante> assinantes = new List<Assinante>();
            assinantes.Add(assinante1);
            assinantes.Add(assinante2);
            assinantes.Add(assinante3);


            Document document = new Document();
            
            Guid id = Guid.NewGuid();
            var date1 = new DateOnly(2022, 06, 27);
            var date2  = new DateOnly(2022, 06, 30);
            JObject content = new JObject();
            document.id_documento = id.ToString();
            document.nome_documento = "contrato de estagiario";
            document.data_criacao = date1;
            document.data_limite = date2;
            document.conteudo =  content;
            document.numero_assinantes = 3;
            document.assinantes = assinantes;
            documentDao.Insert(document);
            CreateEvent(document);
        }
        public void CreateEvent(Document document){
             
            
            Guid uuid = Guid.NewGuid();
            Event event1 = new Event();

            event1.id = uuid.ToString();
            event1.specVersion = "1.0";
            event1.source = "/product/domain/subdomain/service";
            event1.type = "2022-03-22T17:41:02";
            event1.subject = "Novo documento criado pendende de assinanaturas";
            event1.correlationID = "";
            event1.dataContentType = "application/json";
            event1.data = document;

            kafkaDispatcher.Producer(event1.ToString());
        }
    }
}