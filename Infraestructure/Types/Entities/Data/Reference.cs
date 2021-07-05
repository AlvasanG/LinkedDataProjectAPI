using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Data
{
    public class Reference
    {
        public string hash { get; set; }
        public IDictionary<string, IList<MainSnak>> snaks { get; set; }
        [JsonProperty("snaks-order")]
        public IList<string> snaksOrder { get; set; }

        public Reference()
        {
            this.hash = string.Empty;
            this.snaks = new Dictionary<string, IList<MainSnak>>();
            this.snaksOrder = new List<string>();
        }

        public Reference(string hash, IDictionary<string, IList<MainSnak>> snaks, IList<string> snaksOrder)
        {
            this.hash = hash;
            this.snaks = snaks;
            this.snaksOrder = snaksOrder;
        }
    }
}
