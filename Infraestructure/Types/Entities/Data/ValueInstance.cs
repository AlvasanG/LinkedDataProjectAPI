using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Data
{
    public class ValueInstance
    {
        public string key { get; set; }
        public Object value { get; set; }

        public ValueInstance(string key, Object value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
