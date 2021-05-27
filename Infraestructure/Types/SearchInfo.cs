namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class SearchInfo
    {
        public string search { get; set; }

        public SearchInfo()
        {
            search = string.Empty;
        }

        public SearchInfo(string search)
        {
            this.search = search;
        }
    }
}
