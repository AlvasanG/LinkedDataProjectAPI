using Newtonsoft.Json;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class HtmlField
    {
        [JsonProperty("*")]
        public string star { get; set; }

        public HtmlField()
        {
            this.star = string.Empty;
        }
    }
}
