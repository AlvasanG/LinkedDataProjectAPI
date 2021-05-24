namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class MainSnak
    {
        public string property { get; set; }
        public string snakType { get; set; }
        public DataValue dataValue { get; set; }
        public MainSnak(string property, string snakType, DataValue dataValue)
        {
            this.property = property;
            this.snakType = snakType;
            this.dataValue = dataValue;
        }
    }
}
