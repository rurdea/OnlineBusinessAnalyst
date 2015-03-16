using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace OnlineBusinessAnalyst
{
    internal class AbortableBackgroundWorker : BackgroundWorker
    {
        private Thread _workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                Thread.ResetAbort(); // prevents ThreadAbortException propagation
            }
        }

        public void Abort()
        {
            if (_workerThread != null)
            {
                _workerThread.Abort();
                _workerThread = null;
            }
        }
    }
}
