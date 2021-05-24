namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Claim
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string type { get; set; }
        public MainSnak mainSnak { get; set; }
        public Claim(string id, string rank, string type, MainSnak mainSnak)
        {
            this.id = id;
            this.rank = rank;
            this.type = type;
            this.mainSnak = mainSnak;
        }
    }
}
