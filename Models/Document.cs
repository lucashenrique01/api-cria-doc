using Newtonsoft.Json.Linq;
namespace api_cria_doc.Models
{    
    public class Document    
    {        
        public string? id_documento {get;set;}        
        public string? nome_documento {get;set;}   
             
        public string? descricao_documento {get;set;}        
        public DateTime date_created {get;set;}        
        public String? limit_date {get;set;}        
        public int signatures_number {get;set;}        
        public string? conteudo {get;set;}        
        public Boolean assinado {get;set;}        
        public List<Assinante> signatures = new List<Assinante>();    

         public override string ToString()        
        {
            return String.Format("--------------------"+
            "id documento = {0}\n"+
            "nome_documento = {1}\n"+
            "descricao_documento = {2}\n"+
            "Data de criação = {3}\n"+
            "Data limite = {4}\n"+
            "Nº de assinantes = {5}\n"+
            "Conteudo = {6}\n"+
            "Assinantes = {7}\n", this.id_documento, this.nome_documento, this.descricao_documento, this.date_created,
            this.limit_date,  this.signatures_number, this.conteudo, this.signatures);
        }
    }
}