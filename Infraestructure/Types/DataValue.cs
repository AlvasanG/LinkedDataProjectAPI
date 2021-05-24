using Newtonsoft.Json.Linq;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class DataValue
    {
        public JToken value { get; set; }
        public string type { get; set; }
        public DataValue(JToken value, string type)
        {
            this.value = value;
            this.type = type;
        }
    }
}
