using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Data
{
    public class ClaimList
    {
        public IDictionary<string, IList<Claim>> claims { get; set; }

        public ClaimList()
        {
            this.claims = new Dictionary<string, IList<Claim>>();
        }

        public ClaimList(IDictionary<string, IList<Claim>> claims)
        {
            this.claims = claims;
        }
    }
}
