namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class MainSnak
    {
        public string snakType { get; set; }
        public string property { get; set; }
        public string hash { get; set; }
        public DataValue dataValue { get; set; }
        public string dataType { get; set; }

        public MainSnak()
        {
            this.property = string.Empty;
            this.snakType = string.Empty;
            this.dataValue = new DataValue();
            this.dataType = string.Empty;
            this.hash = string.Empty;
        }

        public MainSnak(string property, string snakType, DataValue dataValue, string dataType, string hash)
        {
            this.property = property;
            this.snakType = snakType;
            this.dataValue = dataValue;
            this.dataType = dataType;
            this.hash = hash;
        }
    }
}
