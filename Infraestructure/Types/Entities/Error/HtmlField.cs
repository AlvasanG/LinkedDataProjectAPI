using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class HtmlField
    {
        [JsonProperty("*")]
        public string star { get; set; }

        public HtmlField()
        {
            this.star = string.Empty;
        }
    }
}
