using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Warning
{
    public class WarningEntities
    {
        [JsonProperty("*")]
        public string star { get; set; }

        public WarningEntities()
        {
            this.star = string.Empty;
        }
    }
}
