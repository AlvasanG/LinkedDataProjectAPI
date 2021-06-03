using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
