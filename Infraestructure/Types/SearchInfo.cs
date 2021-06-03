namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class SearchInfo
    {
        public string search { get; set; }

        public SearchInfo()
        {
            this.search = string.Empty;
        }

        public SearchInfo(string search)
        {
            this.search = search;
        }
    }
}
