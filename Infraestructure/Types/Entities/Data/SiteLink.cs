using System.Collections;

namespace LinkedDataProjectAPI.Infraestructure.Types
{
    public class SiteLink
    {

        public string site { get; set; }
        public string title { get; set; }
        public IList badges { get; set; }

        public SiteLink()
        {
            site = string.Empty;
            title = string.Empty;
            badges = new ArrayList();
        }

        public SiteLink(string site, string title, IList badges)
        {
            this.site = site;
            this.title = title;
            this.badges = badges;
        }
    }
}
