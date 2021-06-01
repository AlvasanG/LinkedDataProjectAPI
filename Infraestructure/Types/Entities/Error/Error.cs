using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Error
    {

        public string code { get; set; }
        public string info { get; set; }
        public int id { get; set; }
        public IEnumerable<Message> messages { get; set; }
        [JsonProperty("*")]
        public string star {get; set; }


        public Error()
        {
            code = string.Empty;
            info = string.Empty;
            star = string.Empty;
        }
    }
}
