namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Warning
    {
        public string main { get; set; }

        public Warning()
        {
            this.main = string.Empty;
        }

        public Warning(string main)
        {
            this.main = main;
        }
    }
}
