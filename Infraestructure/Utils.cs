using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure
{
    public class Utils
    {
        private static IDictionary<string, string> _supportedEntitiesParameters = new Dictionary<string, string>()
        {
            {"info", "info"},
            {"sitelinks", "sitelinks"},
            {"aliases", "aliases"},
            {"labels", "labels"},
            {"descriptions", "descriptions"},
            {"claims", "claims"},
            {"datatype", "datatype"}
        };

        public static bool CheckCorrectParametersGetEntities(string[] props)
        {
            if(props == null)
            {
                return true;
            }
            foreach(var p in props)
            {
                if (_supportedEntitiesParameters[p] == null)
                    return false;
            }
            return true;
        }
    }
}
