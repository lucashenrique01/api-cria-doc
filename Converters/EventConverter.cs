using Newtonsoft.Json;
using api_cria_doc.DTO;

namespace api_cria_doc.Converters
{
    public class EventConverter
    {
        public static EventDto jsonToEvent(string jsonString){
            EventDto evento = new EventDto();
            evento = JsonConvert.DeserializeObject<EventDto>(jsonString);            
            return evento;
        }
    }
}