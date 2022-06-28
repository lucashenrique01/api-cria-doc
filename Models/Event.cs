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
        public Document? data {get;set;}
        public Event(string id, string specVersion, string source, string type, string subject, string time, string correlationid,  
        string datacontentype, Document data)        
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

        public override string ToString()        
        {            
            return String.Format("id: {0} /n"+
            "specVersion: {1} /n"+
            "source: {2} /n"+
            "type: {3} /n"+
            "subject: {4} /n"+
            "time: {5} /n"+
            "correlationID: {6} /n"+
            "dataContentType: {7} /n"+
            "data: {8} /n", this.id, this.specVersion, this.source, this.type, this.subject, this.time,
            this.correlationID, this.dataContentType, this.data);        
        } 
    }
}