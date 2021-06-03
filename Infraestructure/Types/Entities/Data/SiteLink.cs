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
            this.site = string.Empty;
            this.title = string.Empty;
            this.badges = new ArrayList();
        }

        public SiteLink(string site, string title, IList badges)
        {
            this.site = site;
            this.title = title;
            this.badges = badges;
        }
    }
}
