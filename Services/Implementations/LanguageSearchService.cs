using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface ILanguageSearchService
    {
        public SearchValuesDto<IDictionary<string, string>> GetLanguagesStartingWith(string lang, int typos);

    }

    public class LanguageSearchService : ILanguageSearchService
    {
        private const string OPERATION = "languagesearch";
        private readonly IWikidataRepository _wikiRepo;

        public LanguageSearchService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public SearchValuesDto<IDictionary<string, string>> GetLanguagesStartingWith(string lang, int typos)
        {
            string qs = Utils.ConcatenateToUrl("search", lang);
            qs += Utils.ConcatenateToUrl("typos", typos.ToString());
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            var data = (stringData.Split(':')[1] == "[]}") ? new LanguageSearchResult() : JsonConvert.DeserializeObject<LanguageSearchResult>(stringData);
            var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
            var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
            return new SearchValuesDto<IDictionary<string, string>>(data.languageSearch, warnings, errors);
        }
    }
}
