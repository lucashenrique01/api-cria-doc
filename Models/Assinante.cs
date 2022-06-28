namespace api_cria_doc.Models
{
    public class Assinante
    {
        public string? nome_assinante {get;set;}
        public string? doc_identificacao {get;set;}

        public Assinante(string nome, string doc){            
            this.nome_assinante = nome;            
            this.doc_identificacao = doc;        
        }

        public override string ToString()        
        {            
            return base.ToString() + ": " + nome_assinante.ToString();        
        }

    }
}