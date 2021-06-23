using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class DataValue
    {
        [JsonIgnore]
        public IDictionary<string, string> value { get; set; }
        [JsonProperty("value")]
        public JToken values { get; set; }
        public string type { get; set; }

        public DataValue()
        {
            this.type = string.Empty;
            this.value = new Dictionary<string, string>();
        }

        public DataValue(IDictionary<string, string> value, string type)
        {
            this.value = value;
            this.type = type;
        }
    }
}
