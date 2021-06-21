using Newtonsoft.Json;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class Main
    {
        [JsonProperty("*")]
        public string star { get; set; }

        public Main()
        {
            this.star = string.Empty;
        }
    }
}
