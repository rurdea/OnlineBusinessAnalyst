using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst
{
    public class LogManager
    {
        private static readonly LogManager _instance = new LogManager();
        private NLog.Logger _logger = NLog.LogManager.GetLogger("OnlineBusinessAnalyst");

        private LogManager()
        {
        }

        public static LogManager Instance
        {
            get
            {
                return _instance;
            }
        }

        public NLog.Logger Logger
        {
            get
            {
                return _logger;
            }
        }
    }
}
