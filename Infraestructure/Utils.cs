using LinkedDataProjectAPI.Infraestructure.Types;
using LinkedDataProjectAPI.Infraestructure.Types.Entities.Data;
using System.Collections.Generic;

namespace LinkedDataProjectAPI.Infraestructure
{
    public class Utils
    {
        /// <summary>
        /// Contains a list of the supported parameters for wbgetentities
        /// </summary>
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

        /// <summary>
        /// Contains a list of the supported ranks for wbgetclaims
        /// </summary>
        public static readonly HashSet<string> _supportedClaimsRanks = new HashSet<string>()
        {
            {"deprecated"},
            {"normal"},
            {"preferred"}
        };

        /// <summary>
        /// Contains a list of the supported props for wbgetclaims
        /// </summary>
        public static readonly HashSet<string> _supportedClaimsProps = new HashSet<string>()
        {
            {"references"}
        };

        /// <summary>
        /// References the data source that will be queried via actions.
        /// Format is json to allow the application to deserialize it.
        /// </summary>
        private static string _url = "https://www.wikidata.org/w/api.php?format=json&action=";

        /// <summary>
        /// Provides the value of the data source
        /// </summary>
        /// <returns> String containing the data source</returns>
        public static string GetUrl()
        {
            return _url;
        }

        /// <summary>
        /// Allows to change the data source by specifing a new data source in 
        /// https://www.example.org/w/api.php format.
        /// </summary>
        /// <param name="newUrl"> The new data source </param>
        public static void SetUrl(string newUrl)
        {
            _url = newUrl;
        }

        /// <summary>
        /// Check whether a set of strings are supported parameters or not.
        /// </summary>
        /// <param name="props">Set of strings to be tested.</param>
        /// <param name="supported">Supported set of strings.</param>
        /// <returns>True if all the strings are supported, else false.</returns>
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

        /// <summary>
        /// Builds a string containing a parameter and its values.
        /// </summary>
        /// <param name="parameter">Parameter to build</param>
        /// <param name="prop">String representing the value of the parameter.</param>
        // /// <returns>An empty string if parameter or prop is null, else a string with format &parameter=prop</returns>
        public static string ConcatenateToUrl(string parameter, string prop)
        {
            return (prop == null || parameter == null) ? "" : "&" + parameter + "=" + prop;
        }

        /// <summary>
        /// Builds a string containing a parameter and its values.
        /// </summary>
        /// <param name="parameter">Parameter to build</param>
        /// <param name="props">List of strings representing the value of the parameter.</param>
        // /// <returns>An empty string if parameter or prop is null, else a string with format &parameter=prop</returns>
        public static string ConcatenateToUrl(string parameter, string[] props)
        {
            if (props == null || props.Length < 1 || parameter == null)
            {
                return "";
            }
            var qs = "&" + parameter + "=";
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

        /// <summary>
        /// Merges two dictionaries together into mainDic.
        /// </summary>
        /// <typeparam name="V">Type of the keys.</typeparam>
        /// <typeparam name="K">Type of the values.</typeparam>
        /// <param name="mainDic">Dictionary where you want to store the values of secondDic.</param>
        /// <param name="secondDic">Dictionary containing values to be added to mainDic.</param>
        public static void Merge<V, K>(ref IDictionary<V, K> mainDic, IDictionary<V, K> secondDic)
        {
            foreach (var entry in secondDic)
            {
                if (!mainDic.ContainsKey(entry.Key))
                    mainDic.Add(entry.Key, entry.Value);
            }
        }

        // /// <summary> Unwraps all occasions of JTokens of an entitie to a Dictionary<string, string> by iterating through the JToken values.</summary>
        /// <param name="data"> Data containing the entities.</param>
        public static void SplitDataValue(ref Data data)
        {
            foreach (var entity in data.entities)
            {
                if (entity.Value.type == "property")
                {
                    continue;
                }
                foreach (var claims in entity.Value.claims)
                {
                    foreach (var claim in claims.Value)
                    {
                        // Values in mainSnak
                        var dataValue = claim.mainSnak.dataValue;
                        if (dataValue.values != null)
                        {
                            dataValue.value = UnwrapDataValue(dataValue);
                        }

                        // Values in references
                        if (claim.references != null && claim.references.Count > 0)
                        {
                            foreach (var token in claim.references)
                            {
                                foreach (var snak in token.snaks)
                                {
                                    foreach (var value in snak.Value)
                                    {
                                        dataValue = value.dataValue;
                                        if (dataValue.values != null)
                                        {
                                            dataValue.value = UnwrapDataValue(dataValue);
                                        }
                                    }
                                }
                            }
                        }

                        // Values in qualifiers
                        if (claim.qualifiers != null && claim.qualifiers.Count > 0)
                        {
                            foreach (var token in claim.qualifiers)
                            {
                                foreach (var snak in token.Value)
                                {
                                    dataValue = snak.dataValue;
                                    if (dataValue.values != null)
                                    {
                                        dataValue.value = UnwrapDataValue(dataValue);
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }


        // /// <summary> Unwraps all occasions of JTokens of an list of claims to a Dictionary<string, string> by iterating through the JToken values.</summary>
        /// <param name="claims"> List of claims containing the JTokens.</param>
        public static void SplitDataValue(ref ClaimList claims)
        {
            foreach (var c in claims.claims.Values)
            {
                foreach (var claim in c)
                {
                    // Values in mainSnak
                    var dataValue = claim.mainSnak.dataValue;
                    if (dataValue.values != null)
                    {
                        dataValue.value = UnwrapDataValue(dataValue);
                    }

                    // Values in references
                    if (claim.references != null && claim.references.Count > 0)
                    {
                        foreach (var token in claim.references)
                        {
                            foreach (var snak in token.snaks)
                            {
                                foreach (var value in snak.Value)
                                {
                                    dataValue = value.dataValue;
                                    if (dataValue.values != null)
                                    {
                                        dataValue.value = UnwrapDataValue(dataValue);
                                    }
                                }
                            }
                        }
                    }

                    // Values in qualifiers
                    if (claim.qualifiers != null && claim.qualifiers.Count > 0)
                    {
                        foreach (var token in claim.qualifiers)
                        {
                            foreach (var snak in token.Value)
                            {
                                dataValue = snak.dataValue;
                                if (dataValue.values != null)
                                {
                                    dataValue.value = UnwrapDataValue(dataValue);
                                }
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Performs the operation of unwrapping and sets the temporary field values to null after it has finished unwrapping.
        /// </summary>
        /// <param name="dataValue">DataValue containing the JToken.</param>
        /// <returns>Dictionary containing the values of the JToken unwrapped.</returns>
        private static Dictionary<string, string> UnwrapDataValue(DataValue dataValue)
        {
            var output = new Dictionary<string, string>();
            if (dataValue.values.HasValues)
            {
                foreach (var token in dataValue.values)
                {
                    output.Add(token.Path.ToString(), token.First.ToString());
                }
            }
            else
            {
                output.Add("value", dataValue.values.ToString());
            }
            dataValue.values = null;
            return output;
        }

    }
}
