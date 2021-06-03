using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string id) : base(GenerateExceptionMessage(id))
        {                
        }

        public EntityNotFoundException(string[] ids) : base(GenerateExceptionMessage(ids))
        {
        }

        private static string GenerateExceptionMessage(string id)
        {
            return "Entity: "+id+" could not be found.";
        }

        private static string GenerateExceptionMessage(string[] ids)
        {
            var result = "Entities: ";
            for (var i = 0; i < ids.Length; i++)
            {
                if (i == 0 && ids.Length > 1)
                {
                    result += ids[i] + "|";
                }
                else if (i == ids.Length - 1)
                {
                    result += ids[i];
                }
                else
                {
                    result += ids[i] + "|";
                }
            }
            result += " could not be found";
            return result;
        }

    }
}
