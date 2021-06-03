namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class SearchResult
    {
        public string id { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string label { get; set; }

        public SearchResult()
        {
            this.id = string.Empty;
            this.url = string.Empty;
            this.description = string.Empty;
            this.label = string.Empty;
        }

        public SearchResult(string id, string url, string description, string label)
        {
            this.id = id;
            this.url = url;
            this.description = description;
            this.label = label;
        }
    }
}
