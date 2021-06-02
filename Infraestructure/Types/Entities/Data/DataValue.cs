using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class DataValue
    {
        [JsonIgnore]
        public IDictionary<string, object> value { get; set; }
        public string type { get; set; }

        public DataValue()
        {
            type = string.Empty;
        }

        public DataValue(IDictionary<string, object> value, string type)
        {
            this.value = value;
            this.type = type;
        }
    }
}
