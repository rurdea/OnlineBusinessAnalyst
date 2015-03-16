using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBusinessAnalyst
{
    public class CrawlerEventArgs : EventArgs
    {
        public string ParentUrl
        {
            get;
            private set;
        }

        public string Url
        {
            get;
            private set;
        }

        public CrawlerEventArgs(string url, string parentUrl)
        {
            this.ParentUrl = parentUrl;
            this.Url = url;
        }
    }

    public class CrawlCompletedEventArgs: CrawlerEventArgs
    {
        public bool Status
        {
            get;
            private set;
        }

        public CrawlCompletedEventArgs(string url, string parentUrl, bool status): base(url, parentUrl)
        {
            this.Status = status;
        }
    }
}
