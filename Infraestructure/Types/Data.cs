using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Data
    {
        public IDictionary<string, Entity> entities { get; set; }
        public int success { get; set; }
        public Data(IDictionary<string, Entity> entities, int success)
        {
            this.entities = entities;
            this.success = success;
        }
    }
}
