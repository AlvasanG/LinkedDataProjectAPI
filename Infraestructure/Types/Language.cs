﻿namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Language
    {
        public string language { get; set; }
        public string value { get; set; }

        public Language()
        {
            language = string.Empty;
            value = string.Empty;
        }

        public Language(string language, string value)
        {
            this.language = language;
            this.value = value;
        }
    }
}
