using System;

namespace LinkedDataProjectAPI.Infraestructure.Types.Entities.Data
{
    public class ValueInstance
    {
        public string key { get; set; }
        public Object value { get; set; }

        public ValueInstance()
        {
            this.key = string.Empty;
        }

        public ValueInstance(string key, Object value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
