using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Data;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure
{
    public class Utils
    {
        public static readonly HashSet<string> _supportedEntitiesParameters = new HashSet<string>()
        {
            {"info"},
            {"sitelinks"},
            {"aliases"},
            {"labels"},
            {"descriptions"},
            {"claims"},
            {"datatype"}
        };

        public static readonly HashSet<string> _supportedClaimsRanks = new HashSet<string>()
        {
            {"deprecated"},
            {"normal"},
            {"preferred"}
        };

        public static readonly HashSet<string> _supportedClaimsProps = new HashSet<string>()
        {
            {"references"}
        };

        public static bool CheckCorrectParameters(string[] props, HashSet<string> supported)
        {
            if (props == null)
            {
                return true;
            }
            foreach (var p in props)
            {
                if (!supported.Contains(p))
                    return false;
            }
            return true;
        }

        public static string ConcatenateToUrl(string propName, string[] props)
        {
            if (props == null || props.Length < 1 || propName == null)
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

        public static string ConcatenateToUrl(string propName, string prop)
        {
            return (prop == null || propName == null) ? "" : "&" + propName + "=" + prop;
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

        public static void SplitDataValue(ref ClaimList claims)
        {
            foreach (var c in claims.claims.Values)
            {
                foreach(var claim in c)
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
}
