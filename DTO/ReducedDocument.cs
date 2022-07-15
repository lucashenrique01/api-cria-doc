using api_cria_doc.Models;
namespace api_cria_doc.DTO
{
    public class ReducedDocument
    {
        public string? id_document {get;set;}
        public int signatures_number {get;set;}
        public String? limit_date {get;set;}
        
        public List<Assinante> signatures = new List<Assinante>();

        
    }
    
}