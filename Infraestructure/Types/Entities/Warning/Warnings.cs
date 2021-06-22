using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class Warnings
    {
        [JsonProperty("main")]
        public Main main { get; set; }

        [JsonProperty("wbgetentities")]
        private Main wbgetentities { set { main = value; } }

        public Warnings()
        {
            this.main = new Main();
        }
    }
}
