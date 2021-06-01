using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class LanguageSearchResult
    {
        public IDictionary<string, string> languageSearch;

        public LanguageSearchResult()
        {
            languageSearch = new Dictionary<string, string>();
        }

        public LanguageSearchResult(string[] _)
        {
            languageSearch = new Dictionary<string, string>();
        }

        public LanguageSearchResult(IDictionary<string, string> languages)
        {
            this.languageSearch = languages;
        }
    }
}
