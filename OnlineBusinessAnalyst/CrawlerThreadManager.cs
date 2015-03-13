using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst
{
    public class CrawlerThreadManager
    {
        #region Members
        // to do: think about thread safety
        // list for storing active crawlers
        private List<CrawlerThread> _activeCrawlers = new List<CrawlerThread>();
        // queue for storing urls that need to be crawled
        private Queue<string> _urlQueue = new Queue<string>();
        // list for visited urls;
        private List<string> _visitedUrls = new List<string>();
        #endregion

        #region Properties
        public bool IsBusy
        {
            get;
            private set;
        }

        public string StartUrl
        {
            get;
            private set;
        }

        public string UrlRegEx
        {
            get;
            private set;
        }

        public string ContentRegEx
        {
            get;
            private set;
        }

        public int MaxThreads
        {
            get;
            private set;
        }

        public int RequestTimeout
        {
            get;
            private set;
        }

        public int SearchTimeout
        {
            get;
            private set;
        }

        public int DownloadTimeout
        {
            get;
            private set;
        }

        public string[] VisitedUrls
        {
            get
            {
                return _visitedUrls.ToArray();
            }
        }
        #endregion

        public CrawlerThreadManager(string startUrl, string urlRegEx, string contentRegEx, int maxThreads, int requestTimeout, int searchTimeout, int downloadTimeout)
        {
            this.StartUrl = startUrl;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = contentRegEx;
            this.MaxThreads = maxThreads;
            this.RequestTimeout = requestTimeout;
            this.SearchTimeout = searchTimeout;
            this.DownloadTimeout = downloadTimeout;
        }

        #region Methods
        #region Public
        public void Start()
        {
            if (!IsBusy)
            {
                _activeCrawlers.Clear();
                AddCrawlerThread(this.StartUrl);
                this.IsBusy = true;
            }
        }

        public void Stop()
        {
            if (IsBusy)
            {
                // force stop all running crawlers
                _activeCrawlers.Where(c => c.IsBusy).ToList().ForEach(c=>c.Stop());
                IsBusy = false;
            }
        }
        #endregion

        #region Private
        private void AddCrawlerThread(string url)
        {
            // clean url
            url = url.Trim();

            if (!_visitedUrls.Contains(url, StringComparer.OrdinalIgnoreCase))
            {
                _visitedUrls.Add(url);
                var thread = new CrawlerThread(url, this.UrlRegEx, this.ContentRegEx);
                thread.UrlFound += new EventHandler<CrawlerThreadEventArgs>(thread_UrlFound);
                thread.ContentFound += new EventHandler<CrawlerThreadEventArgs>(thread_ContentFound);
                thread.CrawlCompleted += new EventHandler(thread_CrawlCompleted);

                _activeCrawlers.Add(thread);

                thread.Start();
            }
            else
            {
                LogManager.Instance.Logger.Debug("Url already visited: {0}.", url);
            }
        }

        #region CrawlerThread Event Handlers
        void thread_CrawlCompleted(object sender, EventArgs e)
        {
            var thread = sender as CrawlerThread;
            _activeCrawlers.Remove(thread);
            // add new crawl if in queue
            if (_urlQueue.Count > 0)
            {
                var url = _urlQueue.Dequeue();
                AddCrawlerThread(url);
            }
        }

        void thread_ContentFound(object sender, CrawlerThreadEventArgs e)
        {
            // save in file
        }

        void thread_UrlFound(object sender, CrawlerThreadEventArgs e)
        {
            // start crawling of add to queue if max threads is reached
            if (_activeCrawlers.Count < MaxThreads)
            {
                AddCrawlerThread(e.Match);
            }
            else
            {
                _urlQueue.Enqueue(e.Match);
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
