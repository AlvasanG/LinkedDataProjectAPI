using System.Collections.Generic;


namespace LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data
{
    public class Search
    {
        public string id { get; set; }
        public string title { get; set; }
        public string pageid { get; set; }
        public string repository { get; set; }
        public string url { get; set; }
        public string concepturi { get; set; }
        public string label { get; set; }
        public string description { get; set; }
        public Match match { get; set; }
        public IList<string> aliases { get; set; }

        public Search()
        {
            this.id = string.Empty;
            this.title = string.Empty;
            this.pageid = string.Empty;
            this.repository = string.Empty;
            this.url = string.Empty;
            this.concepturi = string.Empty;
            this.label = string.Empty;
            this.description = string.Empty;
            this.match = new Match();
            this.aliases = new List<string>();
        }

        public Search(string id, string title, string pageid, string repository, string url, string concepturi, string label, string description, Match match, IList<string> aliases)
        {
            this.id = id;
            this.title = title;
            this.pageid = pageid;
            this.repository = repository;
            this.url = url;
            this.concepturi = concepturi;
            this.label = label;
            this.description = description;
            this.match = match;
            this.aliases = aliases;
        }
    }
}
