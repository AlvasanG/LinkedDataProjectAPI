namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Search
    {
        public SearchInfo searchInfo { get; set; }
        public SearchResult search { get; set; }
        public int success { get; set; }
        public Search(SearchInfo searchInfo, SearchResult searchResult, int success)
        {
            this.searchInfo = searchInfo;
            this.search = searchResult;
            this.success = success;
        }
    }
}
