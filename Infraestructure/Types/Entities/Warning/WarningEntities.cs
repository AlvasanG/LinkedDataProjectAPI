using Newtonsoft.Json;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class WarningEntities
    {
        [JsonProperty("*")]
        public string star { get; set; }

        public WarningEntities()
        {
            this.star = string.Empty;
        }
    }
}
