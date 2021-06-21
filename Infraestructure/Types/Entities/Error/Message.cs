using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Message
    {
        public string name { get; set; }
        public IEnumerable<string> parameters { get; set; }
        public HtmlField html { get; set; }

        public Message()
        {
            this.name = string.Empty;
            this.parameters = new List<string>();
            this.html = new HtmlField();
        }

    }
}
