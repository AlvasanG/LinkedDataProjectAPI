using LinkedDataProjectAPI.Infraestructure.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkedDataProjectAPI.Infraestructure
{
    public class Utils
    {
        private static readonly IDictionary<string, string> _supportedEntitiesParameters = new Dictionary<string, string>()
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
                if (!_supportedEntitiesParameters.ContainsKey(p))
                    return false;
            }
            return true;
        }

        public static string ConcatenateToUrl(string propName, string[] props)
        {
            if (props == null || props.Length < 1)
            {
                return "";
            }
            var qs = "&" + propName + "=";
            for (var i = 0; i < props.Length; i++)
            {
                if (i == 0 && props.Length > 1)
                {
                    qs += props[i] + "|";
                }
                else if (i == props.Length - 1)
                {
                    qs += props[i];
                }
                else
                {
                    qs += props[i] + "|";
                }
            }
            return qs;
        }

        public static void Merge<V, K>(ref IDictionary<V, K> mainDic, IDictionary<V, K> secondDic)
        {
            foreach(var entry in secondDic)
            {
                if(!mainDic.ContainsKey(entry.Key))
                    mainDic.Add(entry.Key, entry.Value);
            }
        }

        public static Data BuildDataFromJson(string stringData)
        {
            var data = JsonConvert.DeserializeObject<Data>(stringData);
            dynamic parsed = JsonConvert.DeserializeObject<ExpandoObject>(stringData, new ExpandoObjectConverter());
            foreach (dynamic entity in (IDictionary<string, dynamic>)parsed.entities)
            {
                var claims = entity.Value.claims;
                foreach (dynamic claim in (IDictionary<string, dynamic>)claims.Value)
                {
                    var c = claim.key;
                }
            }
            return data;
        }

    }
}
