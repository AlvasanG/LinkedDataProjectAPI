using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class LanguageSearchResult
    {
        public IDictionary<string, string> languages;

        public LanguageSearchResult()
        {
            languages = new Dictionary<string, string>();
        }

        public LanguageSearchResult(IDictionary<string,string> languages)
        {
            this.languages = languages;
        }
    }
}
