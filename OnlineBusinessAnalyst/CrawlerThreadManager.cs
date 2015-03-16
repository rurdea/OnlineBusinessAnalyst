using OnlineBusinessAnalyst.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst
{
    public class CrawlerThreadManager
    {
        #region Members
        // to do: think about thread safety
        // list for storing active crawlers
        private ConcurrentList<CrawlerThread> _activeCrawlers = new ConcurrentList<CrawlerThread>();
        // queue for storing urls that need to be crawled
        private ConcurrentQueue<CrawlerThread> _crawlerQueue = new ConcurrentQueue<CrawlerThread>();
        // list for visited urls;
        private ConcurrentList<string> _visitedUrls = new ConcurrentList<string>();
        // content saver instance
        private ContentSaver.ContentSaver _contentSaver;
        #endregion

        #region Events
        public event EventHandler<CrawlerEventArgs> CrawlStarted;
        public event EventHandler<ProgressChangedEventArgs> CrawlProgressChanged;
        public event EventHandler<CrawlCompletedEventArgs> CrawlCompleted;
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

        public int SaveBuffer
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

        public CrawlerThreadManager(string startUrl, string urlRegEx, string contentRegEx, int maxThreads, int requestTimeout, int searchTimeout, int downloadTimeout, int saveBuffer, string storageInfo)
        {
            this.StartUrl = startUrl;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = contentRegEx;
            this.MaxThreads = maxThreads;
            this.RequestTimeout = requestTimeout;
            this.SearchTimeout = searchTimeout;
            this.DownloadTimeout = downloadTimeout;
            this.SaveBuffer = saveBuffer;
            InitializeStorage(storageInfo);
        }

        #region Methods
        #region Public
        public void Start()
        {
            if (!IsBusy)
            {
                _activeCrawlers.Clear();
                var startThread = InitializeCrawlerThread(this.StartUrl, null);
                StartCrawlerThread(startThread);
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
        private void InitializeStorage(string storageInfo)
        {
            string[] split = !string.IsNullOrWhiteSpace(storageInfo) ? storageInfo.Split(';') : null;
            if (split != null && split.Length >= 2)
            {
                switch (split[0].Trim().ToLower())
                {
                    case "file":
                        _contentSaver = new ContentSaver.FileContentSaver(split[1].Trim(), this.SaveBuffer);
                        break;
                    // add different storages here
                }
            }
            
            if (_contentSaver==null)
            {
                LogManager.Instance.Logger.Warn("Invalid storage information, crawled contents will not be saved. Storage info: {0}.", storageInfo);
            }
        }

        private CrawlerThread InitializeCrawlerThread(string url, string parentUrl)
        {
            // clean urls
            url = url.Trim();
            parentUrl = parentUrl != null ? parentUrl.Trim() : parentUrl;

            var thread = new CrawlerThread(url, parentUrl, this.UrlRegEx, this.ContentRegEx, this.RequestTimeout, this.DownloadTimeout, this.SearchTimeout);
            thread.UrlFound += new EventHandler<CrawlerThreadEventArgs>(thread_UrlFound);
            thread.ContentFound += new EventHandler<CrawlerThreadEventArgs>(thread_ContentFound);
            thread.CrawlCompleted += new EventHandler(thread_CrawlCompleted);
            thread.ProgressChanged += thread_ProgressChanged;

            return thread;
        }

        private void TerminateThread(CrawlerThread thread)
        {
            thread.UrlFound -= new EventHandler<CrawlerThreadEventArgs>(thread_UrlFound);
            thread.ContentFound += new EventHandler<CrawlerThreadEventArgs>(thread_ContentFound);
            thread.CrawlCompleted += new EventHandler(thread_CrawlCompleted);
            thread.ProgressChanged += thread_ProgressChanged;
            thread.Dispose();
        }

        private void StartCrawlerThread(CrawlerThread thread)
        {
            _visitedUrls.Add(thread.Url);
            _activeCrawlers.Add(thread);
            if (CrawlStarted!=null)
            {
                CrawlStarted(this, new CrawlerEventArgs(thread.Url, thread.ParentUrl));
            }
            thread.Start();
        }

        #region CrawlerThread Event Handlers
        void thread_CrawlCompleted(object sender, EventArgs e)
        {
            var thread = sender as CrawlerThread;
            _activeCrawlers.Remove(thread);

            // fire crawl completed to the ui
            if (CrawlCompleted!=null)
            {
                CrawlCompleted(this, new CrawlCompletedEventArgs(thread.Url, thread.ParentUrl, thread.CrawlStatus));
            }
            // terminate the thread
            TerminateThread(thread);

            // add new crawl if in queue
            if (_crawlerQueue.Count > 0)
            {
                var newThread = _crawlerQueue.Dequeue();
                StartCrawlerThread(newThread);
            }
            else if (_activeCrawlers.Count == 0)
            { // save remaining content items if no other crawl exists
                if (_contentSaver!=null)
                {
                    _contentSaver.SaveBuffer();
                }
            }
        }

        void thread_ContentFound(object sender, CrawlerThreadEventArgs e)
        {
            if (_contentSaver != null)
            {
                _contentSaver.SaveContentItem(e.Match);
            }
        }

        void thread_UrlFound(object sender, CrawlerThreadEventArgs e)
        {
            if (!_visitedUrls.Contains(e.Match, StringComparer.OrdinalIgnoreCase))
            {
                var thread = sender as CrawlerThread;
                var newThread = InitializeCrawlerThread(e.Match, thread.Url);            
                // start crawling of add to queue if max threads is reached
                if (_activeCrawlers.Count < MaxThreads)
                {
                    StartCrawlerThread(newThread);
                }
                else
                {
                    _crawlerQueue.Enqueue(newThread);
                }
            }
            else
            {
                LogManager.Instance.Logger.Debug("Url already visited: {0}.", e.Match);
            }
        }

        void thread_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if (CrawlProgressChanged != null)
            {
                var thread = sender as CrawlerThread;
                CrawlProgressChanged(this, new ProgressChangedEventArgs(e.ProgressPercentage, new CrawlerEventArgs(thread.Url, thread.ParentUrl)));
            }
        }
        #endregion
        #endregion
        #endregion
    }
}
