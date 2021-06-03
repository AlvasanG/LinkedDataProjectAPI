using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class DataValue
    {
        [JsonIgnore]
        public IDictionary<string, string> values { get; set; }
        public JToken value { get; set; }
        public string type { get; set; }

        public DataValue()
        {
            this.type = string.Empty;
            this.values = new Dictionary<string, string>();
        }

        public DataValue(IDictionary<string, string> value, string type)
        {
            this.values = value;
            this.type = type;
        }
    }
}
