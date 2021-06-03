namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class ErrorMessage
    {
        public Error error { get; set; }
        public string servedBy { get; set; }

        public ErrorMessage()
        {
            this.error = new Error();
            this.servedBy = string.Empty;
        }
    }
}
