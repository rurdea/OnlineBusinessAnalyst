using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalystCrawler.Model
{
    public class DisplayNodeModel
    {
        public int Index { get; set; }
        public string ParentUrl { get; set; }
        public string Url { get; set; }
        public int Progress { get; set; }
    }
}
