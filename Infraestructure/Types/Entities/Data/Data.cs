using System;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Data
    {
        public IDictionary<string, Entity> entities { get; set; }
        public bool success { get; set; }

        public Data()
        {
            this.entities = new Dictionary<string, Entity>();
            this.success = false;
        }

        public Data(IDictionary<string, Entity> entities, int success)
        {
            this.entities = entities;
            this.success = Convert.ToBoolean(success);
        }
    }
}
