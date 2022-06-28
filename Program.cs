using System;
using System.Threading;
using api_cria_doc.DAO;
using api_cria_doc.Services;
namespace Main
{    
    class Program    
    {        
        static void Main(string[] args)        
        {            
            DocumentDao documentDao = new DocumentDao ();
            DocumentService documentService = new DocumentService();
            //documentService.CreateDocument();
            documentDao.Consumer();
        }    
    }
}