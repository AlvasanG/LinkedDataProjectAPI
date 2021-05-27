using System;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Search
    {
        public SearchInfo searchInfo { get; set; }
        public SearchResult search { get; set; }
        public bool success { get; set; }

        public Search()
        {
            searchInfo = new SearchInfo();
            search = new SearchResult();
            success = false;
        }

        public Search(SearchInfo searchInfo, SearchResult searchResult, int success)
        {
            this.searchInfo = searchInfo;
            this.search = searchResult;
            this.success = Convert.ToBoolean(success);
        }
    }
}
