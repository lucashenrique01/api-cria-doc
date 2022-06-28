using Newtonsoft.Json.Linq;
namespace api_cria_doc.Models
{    
    public class Document    
    {        
        public string? id_documento {get;set;}        
        public string? nome_documento {get;set;}        
        public string? descricao_documento {get;set;}        
        public DateOnly data_criacao {get;set;}        
        public DateOnly data_limite {get;set;}        
        public int numero_assinantes {get;set;}        
        public JObject? conteudo {get;set;}        
        public Boolean assinado {get;set;}        
        public List<Assinante> assinantes = new List<Assinante>();    
    }
}