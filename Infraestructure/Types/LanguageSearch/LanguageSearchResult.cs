using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class LanguageSearchResult
    {
        public IDictionary<string, string> languageSearch;

        public LanguageSearchResult()
        {
            this.languageSearch = new Dictionary<string, string>();
        }
    }
}
