﻿using System;
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
        #endregion

        public CrawlerThreadManager(string startUrl, string urlRegEx, string contentRegEx, int maxThreads, int requestTimeout, int searchTimeout, int downloadTimeout)
        {
            this.StartUrl = startUrl;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = ContentRegEx;
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
            var thread = new CrawlerThread(this.StartUrl, this.UrlRegEx, this.ContentRegEx);
            thread.UrlFound += new EventHandler(thread_UrlFound);
            thread.ContentFound += new EventHandler(thread_ContentFound);
            thread.CrawlCompleted += new EventHandler(thread_CrawlCompleted);

            _activeCrawlers.Add(thread);

            thread.Start();
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

        void thread_ContentFound(object sender, EventArgs e)
        {
            // save in file
        }

        void thread_UrlFound(object sender, EventArgs e)
        {
            // start crawling of add to queue if max threads is reached
            if (_activeCrawlers.Count < MaxThreads)
            {
                AddCrawlerThread(e.ToString());
            }
            else
            {
                _urlQueue.Enqueue(e.ToString());
            }
        }
        #endregion
        #endregion
        #endregion
    }
}