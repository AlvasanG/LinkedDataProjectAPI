namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Claim
    {
        public string id { get; set; }
        public string rank { get; set; }
        public string type { get; set; }
        public MainSnak mainSnak { get; set; }

        public Claim()
        {
            this.id = string.Empty;
            this.rank = string.Empty;
            this.type = string.Empty;
            this.mainSnak = new MainSnak();
        }

        public Claim(string id, string rank, string type, MainSnak mainSnak)
        {
            this.id = id;
            this.rank = rank;
            this.type = type;
            this.mainSnak = mainSnak;
        }
    }
}
