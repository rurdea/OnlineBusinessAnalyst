using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;

namespace OnlineBusinessAnalyst
{
    public class CrawlerThread
    {
        #region Members
        private AbortableBackgroundWorker _worker;
        private Timer _searchTimer;
        #endregion

        #region Properties
        public bool IsBusy
        {
            get
            {
                return _worker.IsBusy;
            }
        }

        public string Url
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

        public int RequestTimeout
        {
            get;
            private set;
        }

        public int DownloadTimeout
        {
            get;
            private set;
        }

        public int SearchTimeout
        {
            get;
            private set;
        }
        #endregion

        #region Events
        public event EventHandler<CrawlerThreadEventArgs> UrlFound;
        public event EventHandler<CrawlerThreadEventArgs> ContentFound;
        public event EventHandler<ProgressChangedEventArgs> ProgressChanged;
        public event EventHandler CrawlCompleted;
        #endregion

        #region Constructor
        public CrawlerThread(string url, string urlRegEx, string contentRegEx, int requestTimeout, int downloadTimeout, int searchTimeout)
        {
            this.Url = url;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = contentRegEx;
            this.RequestTimeout = requestTimeout;
            this.DownloadTimeout = downloadTimeout;
            this.SearchTimeout = searchTimeout;

            _worker = new AbortableBackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.WorkerReportsProgress = true;
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(_worker_ProgressChanged);

            _searchTimer = new Timer(this.SearchTimeout);
            _searchTimer.Elapsed += _searchTimer_Elapsed;
        }

        
        #endregion

        #region Methods
        #region Public
        public void Start()
        {
            if (!_worker.IsBusy)
            {
                _worker.RunWorkerAsync();
            }
        }

        public void Stop()
        {
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
            }
        }
        #endregion


        #region Private
        #region Worker Event Handlers
        void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.ProgressChanged!=null)
            {
                this.ProgressChanged(this, e);
            }
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // to do: handle redirects?
                
                var request = HttpWebRequest.Create(this.Url) as HttpWebRequest;
                request.Timeout = this.RequestTimeout;
                request.ReadWriteTimeout = this.DownloadTimeout;
                var response = request.GetResponse() as HttpWebResponse;
                
                var status = response != null ? response.StatusCode : HttpStatusCode.ServiceUnavailable;

                LogManager.Instance.Logger.Info("Request: {0}\tStatus: {1}", this.Url, status.ToString());
                if (status == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        // to do: may be a good idea to parse the content in chunks rather than all at once
                        // optimization needed

                        var content = reader.ReadToEnd();

                        if (_worker.CancellationPending)
                        {
                            return;
                        }
                        else
                        {
                            _worker.ReportProgress(33);
                        }

                        var urlExpr = new Regex(this.UrlRegEx);
                        var urlResults = urlExpr.Matches(content);
                        foreach (Match match in urlResults)
                        {
                            // fire url found
                            if (UrlFound != null)
                            {
                                UrlFound(this, new CrawlerThreadEventArgs(match.Value));
                            }
                        }

                        if (_worker.CancellationPending)
                        {
                            return;
                        }
                        else
                        {
                            _worker.ReportProgress(66);
                        }

                        var contentExpr = new Regex(this.ContentRegEx);
                        var contentResults = contentExpr.Matches(content);
                        foreach(Match match in contentResults)
                        {
                            if (ContentFound!=null)
                            {
                                ContentFound(this, new CrawlerThreadEventArgs(match.Value));
                            }
                        }

                        _worker.ReportProgress(100);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Logger.Error("Error making or processing request.",  ex);
            }
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.CrawlCompleted != null)
            {
                this.CrawlCompleted(this, null);
            }
        }
        #endregion

        #region Search Timer Event Handlers
        void _searchTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_worker.IsBusy)
            {
                _worker.Abort();
                LogManager.Instance.Logger.Warn("Search timeout elapsed, crawling stopped. Url: {0}.", this.Url);
            }

            _searchTimer.Stop();
        }
        #endregion
        #endregion
        #endregion
    }
}
