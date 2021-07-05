using LinkedDataProjectAPI.Repository;

namespace LinkedDataProjectAPI.Services.Implementations
{
    public interface IWikidataService
    {
        public bool SetUrl(string newUrl);
    }

    public class WikidataService : IWikidataService
    {
        private readonly IWikidataRepository _wikiRepo;

        public WikidataService(IWikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
        }

        public bool SetUrl(string newUrl)
        {
            return _wikiRepo.SetUrl(newUrl);
        }

    }
}
