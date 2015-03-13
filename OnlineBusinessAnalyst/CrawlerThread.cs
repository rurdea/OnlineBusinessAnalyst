using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Diagnostics;

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
        public event EventHandler UrlFound;
        public event EventHandler ContentFound;
        public event EventHandler CrawlCompleted;
        #endregion

        #region Constructor
        public CrawlerThread(string url, string urlRegEx, string contentRegEx)
        {
            this.Url = url;
            this.UrlRegEx = urlRegEx;
            this.ContentRegEx = ContentRegEx;

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
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        // to do: apply the regex on the response
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // fire crawl completed
        }
        #endregion
        #endregion
        #endregion
    }
}
