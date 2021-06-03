using System;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Entity
    {
        public string title { get; set; }
        public string id { get; set; }
        public int ns { get; set; }
        public int lastRevId { get; set; }
        public DateTime modified { get; set; }
        public string type { get; set; }
        public IDictionary<string, Language> labes { get; set; }
        public IDictionary<string, IList<Language>> aliases { get; set; }
        public IDictionary<string, Language> descriptions { get; set; }
        public IDictionary<string, IList<Claim>> claims { get; set; }
        public IDictionary<string, SiteLink> siteLinks { get; set; }

        public Entity()
        {
            this.title = string.Empty;
            this.id = string.Empty;
            this.ns = 0;
            this.lastRevId = 0;
            this.modified = new DateTime();
            this.type = string.Empty;
            this.labes = new Dictionary<string, Language>();
            this.aliases = new Dictionary<string, IList<Language>>();
            this.descriptions = new Dictionary<string, Language>();
            this.claims = new Dictionary<string, IList<Claim>>();
            this.siteLinks = new Dictionary<string, SiteLink>();
        }

        public Entity(string title, string id, int ns, int lastRevId,
            DateTime modified, string type, IDictionary<string, Language> labes,
            IDictionary<string, IList<Language>> aliases, IDictionary<string, Language> descriptions,
            IDictionary<string, IList<Claim>> claims, IDictionary<string, SiteLink> siteLinks)
        {
            this.title = title;
            this.id = id;
            this.ns = ns;
            this.lastRevId = lastRevId;
            this.modified = modified;
            this.type = type;
            this.labes = labes;
            this.aliases = aliases;
            this.descriptions = descriptions;
            this.claims = claims;
            this.siteLinks = siteLinks;
        }
    }
}
