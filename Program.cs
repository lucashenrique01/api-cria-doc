using System;
using System.Threading;
using api_cria_doc.Contexts;
using api_cria_doc.Services;
namespace Main
{    
    class Program    
    {        
        static void Main(string[] args)        
        {            
            Thread thr1 = new Thread(Consumer);
            Thread thr2 = new Thread(Menu);
            thr1.Start();
            thr2.Start();
        }   
        private static void Consumer(){
            KafkaConsumer kafkaConsumer = new KafkaConsumer();
            kafkaConsumer.Consumer();
        }
        private static void Menu(){
            DocumentService documentService = new DocumentService();            
           
            bool exit_menu = false;
            while(!exit_menu){
                Console.WriteLine("|------------MENU------------|");
                Console.WriteLine("|1 - Criar um novo documento |");    
                Console.WriteLine("|2 - Ver documentos criados  |");                
                Console.WriteLine("|3 - Cancelar um documento   |");
                Console.WriteLine("|4 - Sair                    |");
                Console.WriteLine("|----------------------------|");
                try{
                    int menu_option = Int32.Parse(Console.ReadLine());
                switch(menu_option){
                    case 1:
                        documentService.CreateDocumentConsole();
                        break;
                    case 2:
                        documentService.GetDocuments();
                        break;
                    case 3:
                        Console.WriteLine("Digite o id do documento: ");
                        string id = Console.ReadLine();
                        documentService.DeleteDocument(id);                      
                        break;
                    case 4:
                        Console.WriteLine("Press <Enter> to exit...");                        
                        if(Console.ReadKey().Key == ConsoleKey.Enter){
                            exit_menu = true;
                            break;
                        }                        
                        break;
                    default: 
                        Console.WriteLine("Digite um opção válida");
                        break;
                }
                }catch (Exception ex){
                    Console.WriteLine(ex);
                }
            }
        } 
    }
}