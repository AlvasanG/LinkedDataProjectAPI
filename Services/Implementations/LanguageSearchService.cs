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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public LanguageSearchResult GetLanguagesStartingWith(string lang);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        public bool CheckLanguageIsSupportedEntities(string[] lang);
    }

    public class LanguageSearchService : ILanguageSearchService
    {
        private const string OPERATION = "languagesearch";
        private readonly WikidataRepository _wikiRepo;
        private readonly IDictionary<string, string> _supportedLanguagesEntities;
        private readonly char[] _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();

        public LanguageSearchService(WikidataRepository wikidataRepository)
        {
            _wikiRepo = wikidataRepository;
            _supportedLanguagesEntities = new Dictionary<string, string>();
            foreach(var letter in _alphabet)
            {
                Utils.Merge<string, string>(ref _supportedLanguagesEntities, GetLanguagesStartingWith(letter.ToString()).languages);
            }
        }

        public LanguageSearchResult GetLanguagesStartingWith(string lang)
        {
            if(lang == null || lang.Trim() == "")
            {
                return new LanguageSearchResult();
            }
            string qs = Utils.ConcatenateToUrl("search", new string[] { lang });
            var stringData = _wikiRepo.PerformAction(OPERATION, qs);
            var data = JsonConvert.DeserializeObject<LanguageSearchResult>(stringData);
            return data;
        }

        public bool CheckLanguageIsSupportedEntities(string[] lang)
        {
            if (lang == null)
            {
                return false;
            }
            var result = true;
            foreach(var l in lang)
            {
                result &=_supportedLanguagesEntities[l] != null;
            }
            return result;
        }
    }
}
