namespace api_cria_doc.Models
{
    public class Assinante
    {
        public string? nome_assinante {get;set;}
        public string? doc_identificacao {get;set;}
        public String? email {get;set;}

        public Assinante(string nome, string doc){            
            this.nome_assinante = nome;            
            this.doc_identificacao = doc;        
        }

        public Assinante(){            
                   
        }

        public override string ToString()        
        {            
            return String.Format("Nome assinante = {0}\n"+
            "Documento de identificação = {1}\n", this.nome_assinante, this.doc_identificacao);        
        }

    }
}