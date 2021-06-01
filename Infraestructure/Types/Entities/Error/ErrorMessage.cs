namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class ErrorMessage
    {
        public Error error { get; set; }
        public string servedBy { get; set; }

        public ErrorMessage()
        {
            error = new Error();
            servedBy = string.Empty;
        }
    }
}
