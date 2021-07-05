using LinkedDataProjectAPI.Infraestructure;
using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.DTOs;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning;
using LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data;
using LinkedDataProjectAPI.Repository;
using Newtonsoft.Json;
using Serilog;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface ISearchEntitiesService
    {
        SearchValuesDto<SearchResultObj> GetSearchEntities(string search, string language, bool strict, string type, int limit, int continueFrom, string props, string useLang);
    }

    public class SearchEntitiesService : ISearchEntitiesService
    {
        private const string OPERATION = "wbsearchentities";
        private readonly IWikidataRepository _wikiRepo;

        public SearchEntitiesService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public SearchValuesDto<SearchResultObj> GetSearchEntities(string search, string language, bool strict, string type, int limit, int continueFrom, string props, string useLang)
        {
            string qs = "";
            qs += Utils.ConcatenateToUrl("search", search);
            qs += Utils.ConcatenateToUrl("language", language);
            qs += Utils.ConcatenateToUrl("strictlanguage", strict.ToString());
            qs += Utils.ConcatenateToUrl("type", type);
            qs += Utils.ConcatenateToUrl("limit", limit.ToString());
            qs += Utils.ConcatenateToUrl("continue", continueFrom.ToString());
            qs += Utils.ConcatenateToUrl("props", props);

            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            try
            {
                var data = JsonConvert.DeserializeObject<SearchResultObj>(stringData);
                var warnings = JsonConvert.DeserializeObject<WarningEntities>(stringData);
                var errors = JsonConvert.DeserializeObject<ErrorMessage>(stringData);
                return new SearchValuesDto<SearchResultObj>(data, warnings, errors);
            }
            catch (JsonException)
            {
                Log.Error("Something went wrong parsing the query response.");
                return new SearchValuesDto<SearchResultObj>();
            }
        }
    }
}
