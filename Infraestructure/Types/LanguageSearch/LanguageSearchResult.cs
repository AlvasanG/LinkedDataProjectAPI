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
            this.languageSearch = new Dictionary<string, string>();
        }
    }
}
