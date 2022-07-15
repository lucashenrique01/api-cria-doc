using api_cria_doc.Models;
using api_cria_doc.DAO;
using api_cria_doc.DTO;
using api_cria_doc.Contexts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api_cria_doc.Services
{
    public class DocumentService
    {
        DocumentDao documentDao = new DocumentDao();
        MongoContext mongoContext = new MongoContext();
        KafkaDispatcher kafkaDispatcher = new KafkaDispatcher();
        
        public void CreateEvent(Document document){
            KafkaDispatcher kafkaDispatcher = new KafkaDispatcher();
            if(document != null){
                Guid uuid = Guid.NewGuid();
                Event event1 = new Event();

                ReducedDocument reducedDocument = new ReducedDocument();
                reducedDocument.id_document = document.id_documento;
                reducedDocument.signatures_number = document.signatures_number;
                reducedDocument.limit_date = document.limit_date;
                reducedDocument.signatures = document.signatures;

                event1.id = uuid.ToString();
                event1.specVersion = "1.0";
                event1.source = "/product/domain/subdomain/service";
                event1.type = "br.com.example.document.created";
                event1.time = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");
                event1.subject = "Novo documento criado pendende de assinanaturas";
                event1.correlationID = "";
                event1.dataContentType = "application/json";
                event1.data = reducedDocument;

                string topic = "br.com.example.document.created";
                kafkaDispatcher.Producer(JsonConvert.SerializeObject(event1, Formatting.Indented), event1.id, topic);
            }else {
                throw new ArgumentNullException();
            }
        }

        public void CreateDocumentConsole(){       
            List<Assinante> assinantes = new List<Assinante>();                
            Document document = new Document();            
            
            Guid id = Guid.NewGuid();
            DateTime date1 = DateTime.Now;            
            JObject content = new JObject();
            document.id_documento = id.ToString();
            Console.Write("Nome do contrato: ");
            document.nome_documento = Console.ReadLine();
            Console.Write("Número de assinantes: ");
            document.signatures_number = Int32.Parse(Console.ReadLine());
            document.date_created = date1;
            Console.WriteLine("Digite a data limete para o documento ser assinadado.");
            Console.Write("Dia: ");
            int dia = Int32.Parse(Console.ReadLine());            
            Console.Write("Mês: ");
            int mes = Int32.Parse(Console.ReadLine());            
            Console.Write("Ano: ");
            int ano = Int32.Parse(Console.ReadLine());           
            var date2  = new DateOnly(ano, mes, dia);
            String dateS = date2.ToString("yyyy-MM-dd");
            document.limit_date = dateS;
            document.conteudo = "conteudo.pdf";
            for(int i = 0; i < document.signatures_number; i++){
                Assinante assinante = new Assinante();
                Console.Write($"Nome do {i+1}º assinante: ");
                assinante.nome_assinante = Console.ReadLine();
                Console.Write($"Email do {i+1}º assinante:");
                assinante.email = Console.ReadLine();
                Console.Write($"Documento de identificação do {i+1}º assinante: ");
                assinante.doc_identificacao = Console.ReadLine();
                assinantes.Add(assinante);
            }            
            document.signatures = assinantes;

            documentDao.Insert(document);
            try{
                Console.WriteLine("tentando lançar evento ...");
                CreateEvent(document);    
            }catch(Exception ex){
                Console.WriteLine(ex);
            }
        }

        public void GetDocuments(){
            documentDao.GetDocuments();
        }
        public void DeleteDocument(string id_document){
            try{
                documentDao.DeleteDocumentByIdDocument(id_document);
                Guid uuid = Guid.NewGuid();
                EventDto eventDto = new EventDto();
                eventDto.id = uuid.ToString();
                eventDto.specVersion = "1.0";
                eventDto.source = "/product/domain/subdomain/service";
                eventDto.type = "br.com.example.document.canceled";
                eventDto.time = DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss");
                eventDto.subject = "Document canceled";
                eventDto.correlationID = "";
                eventDto.dataContentType = "application/json";
                DataIdDocument dataIdDocument = new DataIdDocument();
                dataIdDocument.idDocument = id_document;
                eventDto.data = dataIdDocument;
                kafkaDispatcher.Producer(JsonConvert.SerializeObject(eventDto, Formatting.Indented),id_document,eventDto.type);
            }catch(Exception ex){
                Console.WriteLine(ex);
            }
                
        }
    }
}