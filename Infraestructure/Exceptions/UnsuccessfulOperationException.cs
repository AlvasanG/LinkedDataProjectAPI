using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Exceptions
{
    public class UnsuccessfulOperationException : Exception
    {
        public UnsuccessfulOperationException(string code, string info) : base(GenerateExceptionMessage(code, info))
        {

        }

        private static string GenerateExceptionMessage(string code, string info)
        {
            return "An error with code " + code + " has occured because of: " + info;
        }
    }
}
