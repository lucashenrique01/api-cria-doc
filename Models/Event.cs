using api_cria_doc.DTO;
using Newtonsoft.Json.Linq;
namespace api_cria_doc.Models
{    
    public class Event    
    {        
        public string? id {get; set;}        
        public string? specVersion {get; set;}        
        public string? source {get; set;}        
        public string? type {get;set;}        
        public string? subject {get;set;}        
        public string? time {get;set;}        
        public string? correlationID {get;set;}        
        public string? dataContentType {get;set;}        
        public ReducedDocument? data {get;set;}
        public Event(string id, string specVersion, string source, string type, string subject, string time, string correlationid,  
        string datacontentype, ReducedDocument data)        
        {
            this.id=id;            
            this.specVersion=specVersion;            
            this.source=source;            
            this.type=type;            
            this.subject=subject;            
            this.time=time;            
            this.correlationID=correlationid;            
            this.dataContentType=datacontentype;            
            this.data=data;       
        }             
        public Event(){
            
        }  

         

        
    }
}