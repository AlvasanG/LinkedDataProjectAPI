using LinkedDataProjectAPI.Infraestructure;
using Serilog;
using System;
using System.IO;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;

namespace LinkedDataProjectAPI.Repository
{
    public interface IWikidataRepository
    {
        public string PerformAction(string action, string qs);
        public bool SetUrl(string newUrl);
    }

    public class WikidataRepository : IWikidataRepository
    {
        private readonly string _url = Utils.GetUrl();

        public WikidataRepository()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public string PerformAction(string action, string qs)
        {
            return FetchUrl(_url + action + qs);
        }

        public bool SetUrl(string newUrl)
        {
            var regex = new Regex(@"(https:\/\/)\w+\.\w+.\w+(\/w\/api.php)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if(regex.IsMatch(newUrl))
            {
                Utils.SetUrl(newUrl + "?format=json&action=");
                return true;
            }
            return false;
        }

        private static string FetchUrl(string url)
        {
            try
            {
                var req = WebRequest.Create(new Uri(url));
                Log.Information(url);
                var resp = req.GetResponse();
                return new StreamReader(resp.GetResponseStream()).ReadToEnd();
            }
            catch (Exception e)
            {
                if (e is SecurityException)
                {
                    Log.Error("There was a problem creating a web request for your URI." +
                        "Check your priviledges.", e);
                }
                if (e is ArgumentNullException || e is ArgumentException)
                {
                    Log.Error("An argument does not fulfill the requirements.", e);
                }
                if (e is NotImplementedException)
                {
                    Log.Error("The method is not being defined on a subclass.", e);
                }
                if (e is NotSupportedException)
                {
                    Log.Error("Operation is not supported.", e);
                }
                if (e is OutOfMemoryException || e is IOException)
                {
                    Log.Error("There was a problem reading the respone.", e);
                }
                Log.Error("Something unexpected went wrong when fecthing from url", e);
            }
            return "";
        }
    }
}
