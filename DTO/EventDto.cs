namespace api_cria_doc.DTO
{
    public class EventDto
    {
        public string? id {get; set;}        
        public string? specVersion {get; set;}        
        public string? source {get; set;}        
        public string? type {get;set;}        
        public string? subject {get;set;}        
        public string? time {get;set;}        
        public string? correlationID {get;set;}        
        public string? dataContentType {get;set;}
        public DataIdDocument? data {get;set;}
        
    }
}