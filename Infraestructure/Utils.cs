using LinkedDataProjectAPI.Infraestructure.Types;
using System.Collections.Generic;

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
            if (props == null)
            {
                return true;
            }
            foreach (var p in props)
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
            foreach (var entry in secondDic)
            {
                if (!mainDic.ContainsKey(entry.Key))
                    mainDic.Add(entry.Key, entry.Value);
            }
        }

        public static void SplitDataValue(ref Data data)
        {
            foreach (var entity in data.entities)
            {
                foreach (var claim in entity.Value.claims)
                {
                    foreach (var c in claim.Value)
                    {
                        var dataValue = c.mainSnak.dataValue;
                        dataValue.values = new Dictionary<string, string>();
                        foreach (var token in dataValue.value)
                        {
                            dataValue.values.Add(token.Path.ToString(), token.First.ToString());
                        }
                    }
                }
            }
        }

        public static void SplitDataValue(ref IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                var dataValue = claim.mainSnak.dataValue;
                dataValue.values = new Dictionary<string, string>();
                foreach (var token in dataValue.value)
                {
                    dataValue.values.Add(token.Path.ToString(), token.First.ToString());
                }
            }
        }

    }
}
