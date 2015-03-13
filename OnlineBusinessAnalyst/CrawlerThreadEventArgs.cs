using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst
{
    public class CrawlerThreadEventArgs : EventArgs
    {
        public string Match
        {
            get;
            private set;
        }

        public CrawlerThreadEventArgs(string match)
        {
            this.Match = match;
        }
    }
}
