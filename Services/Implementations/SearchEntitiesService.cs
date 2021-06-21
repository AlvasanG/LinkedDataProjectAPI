using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface ISearchEntitiesService
    {
        SearchResult GetSearchEntities(string search, string language, bool strict, string type, int limit, int continueFrom, string props);
    }

    public class SearchEntitiesService : ISearchEntitiesService
    {
        private const string OPERATION = "wbsearchentities";
        private readonly IWikidataRepository _wikiRepo;

        public SearchEntitiesService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public SearchResult GetSearchEntities(string search, string language, bool strict, string type, int limit, int continueFrom, string props)
        {
            throw new NotImplementedException();
        }
    }
}
