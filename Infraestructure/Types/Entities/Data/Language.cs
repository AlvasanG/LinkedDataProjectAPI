namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Language
    {
        public string language { get; set; }
        public string value { get; set; }

        public Language()
        {
            this.language = string.Empty;
            this.value = string.Empty;
        }

        public Language(string language, string value)
        {
            this.language = language;
            this.value = value;
        }
    }
}
