using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Data
{
    public class Qualifier
    {
        public IDictionary<string, IList<MainSnak>> qualifiers { get; set; }
        [JsonProperty("qualifiers-order")]
        public IList<string> qualifierOrder { get; set; }

        public Qualifier()
        {
            this.qualifiers = new Dictionary<string, IList<MainSnak>>();
            this.qualifierOrder = new List<string>();
        }

        public Qualifier(IDictionary<string, IList<MainSnak>> snaks, IList<string> qualifierOrder)
        {
            this.qualifiers = snaks;
            this.qualifierOrder = qualifierOrder;
        }
    }
}
