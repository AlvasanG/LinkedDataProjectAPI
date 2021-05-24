using Serilog;
using System;
using System.IO;
using System.Net;
using System.Security;

namespace LinkedDataProjectAPI.Repository
{
    public interface IWikidataRepository
    {
        public string PerformAction(string action, string qs);
    }

    public class WikidataRepository : IWikidataRepository
    {
        private readonly string _url = "https://www.wikidata.org/w/api.php?format=json&action=";

        public WikidataRepository()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public string PerformAction(string action, string qs)
        {
            return FetchUrl(_url + action + qs);
        }

        private static string FetchUrl(string url)
        {
            try
            {
                var req = WebRequest.Create(new Uri(url));
                var resp = req.GetResponse();
                return new StreamReader(resp.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                if(e is SecurityException)
                {
                    Log.Error("There was a problem creating a web request for your URI." +
                        "Check your priviledges.", e);
                }
                if(e is ArgumentNullException || e is ArgumentException)
                {
                    Log.Error("An argument does not fulfill the requirements.", e);
                }
                if(e is NotImplementedException)
                {
                    Log.Error("The method is not being defined on a subclass.", e);
                }
                if(e is NotSupportedException)
                {
                    Log.Error("Operation is not supported.", e);
                }
                if(e is OutOfMemoryException || e is IOException)
                {
                    Log.Error("There was a problem reading the respone.", e);
                }
                Log.Error("Something unexpected went wrong when fecthing from url", e);
            }
            return "";
        }
    }
}
