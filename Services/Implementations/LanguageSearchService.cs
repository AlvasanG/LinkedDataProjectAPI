using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface ILanguageSearchService
    {
        public IDictionary<string, string> GetLanguagesStartingWith(string lang);

    }

    public class LanguageSearchService : ILanguageSearchService
    {
        private const string OPERATION = "languagesearch";
        private readonly IWikidataRepository _wikiRepo;

        public LanguageSearchService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public IDictionary<string, string> GetLanguagesStartingWith(string lang)
        {
            if(lang == null || lang.Trim() == "")
            {
                return new Dictionary<string, string>();
            }
            string qs = Utils.ConcatenateToUrl("search", new string[] { lang });
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            if (stringData.Split(':')[1] == "[]}")
            {
                return new Dictionary<string, string>();
            }
            var data = JsonConvert.DeserializeObject<LanguageSearchResult>(stringData);
            return data.languageSearch;
        }
    }
}
