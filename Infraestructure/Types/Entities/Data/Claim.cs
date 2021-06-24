using LinkedDataProjectAPI.Infraestructure.Types.Entities.Data;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Claim
    {
        public MainSnak mainSnak { get; set; }
        public string type { get; set; }
        public IDictionary<string, IList<MainSnak>> qualifiers { get; set; }
        [JsonProperty("qualifiers-order")]
        public IList<string> qualifierOrder { get; set; }
        public string id { get; set; }
        public string rank { get; set; }
        public IList<Reference> references { get; set; }

        public Claim()
        {
            this.id = string.Empty;
            this.rank = string.Empty;
            this.type = string.Empty;
            this.mainSnak = new MainSnak();
            this.references = new List<Reference>();
            this.qualifiers = new Dictionary<string, IList<MainSnak>>();
            this.qualifierOrder = new List<string>();
        }

        public Claim(string id, string rank, string type, MainSnak mainSnak, IList<Reference> reference, IDictionary<string, IList<MainSnak>> snaks, IList<string> qualifierOrder)
        {
            this.id = id;
            this.rank = rank;
            this.type = type;
            this.mainSnak = mainSnak;
            this.references = reference;
            this.qualifiers = snaks;
            this.qualifierOrder = qualifierOrder;
        }
    }
}
