using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OnlineBusinessAnalystCrawler
{
    public class Logger
    {
        public static void Error(Exception ex, string file)
        {
            File.AppendAllText(file, ex.Message + "\n" + ex.StackTrace+ Environment.NewLine);
           
        }
    }
}
