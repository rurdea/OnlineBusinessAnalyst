using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace OnlineBusinessAnalyst
{
    public class CrawlerThread
    {
        #region Members
        private BackgroundWorker _worker;
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
        #endregion

        #region Events
        public event EventHandler<CrawlerThreadEventArgs> UrlFound;
        public event EventHandler<CrawlerThreadEventArgs> ContentFound;
        public event EventHandler CrawlCompleted;
        #endregion

        #region Constructor
        public CrawlerThread(string url, string urlRegEx, string contentRegEx)
        {
            this.Url = url;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = contentRegEx;

            _worker = new BackgroundWorker();
            _worker.WorkerSupportsCancellation = true;
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.ProgressChanged += new ProgressChangedEventHandler(_worker_ProgressChanged);
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
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // to do: handle redirects?
                
                var request = HttpWebRequest.Create(this.Url) as HttpWebRequest;
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

                        var contentExpr = new Regex(this.ContentRegEx);
                        var contentResults = contentExpr.Matches(content);
                        foreach(Match match in contentResults)
                        {
                            if (ContentFound!=null)
                            {
                                ContentFound(this, new CrawlerThreadEventArgs(match.Value));
                            }
                        }
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
        #endregion
        #endregion
    }
}
