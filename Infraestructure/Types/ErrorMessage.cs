using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class ErrorMessage
    {
        public Error error { get; set; }
        public string servedBy { get; set; }

        public ErrorMessage(Error error, string servedby)
        {
            this.error = error;
            this.servedBy = servedby;
        }
    }
}
