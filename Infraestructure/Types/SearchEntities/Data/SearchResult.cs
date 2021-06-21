using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types.SearchEntities.Data
{
    public class SearchResult
    {
        public SearchInfo searchInfo { get; set; }
        public IList<Search> search { get; set; }
        [JsonProperty("search-continue")]
        public int searchContinue { get; set; }
        public bool success { get; set; }

        public SearchResult()
        {
            this.searchInfo = new SearchInfo();
            this.search = new List<Search>();
            this.searchContinue = 0;
            this.success = false;
        }

        public SearchResult(SearchInfo searchInfo, IList<Search> search, int searchContinue, int success)
        {
            this.searchInfo = searchInfo;
            this.search = search;
            this.searchContinue = searchContinue;
            this.success = Convert.ToBoolean(success);
        }
    }
}
