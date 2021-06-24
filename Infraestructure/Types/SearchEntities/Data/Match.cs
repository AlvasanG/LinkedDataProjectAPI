namespace LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data
{
    public class Match
    {
        public string type { get; set; }
        public string language { get; set; }
        public string text { get; set; }

        public Match()
        {
            this.type = string.Empty;
            this.language = string.Empty;
            this.text = string.Empty;
        }

        public Match(string type, string language, string text)
        {
            this.type = type;
            this.language = language;
            this.text = text;
        }
    }
}
