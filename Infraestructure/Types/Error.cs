using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class Error
    {

        public string code { get; set; }
        public string info { get; set; }

        public Error()
        {
            code = string.Empty;
            info = string.Empty;
        }

        public Error(string code, string info)
        {
            this.code = code;
            this.info = info;
        }

    }
}
