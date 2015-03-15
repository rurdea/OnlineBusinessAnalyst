using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OnlineBusinessAnalyst;
using OnlineBusinessAnalystCrawler.Properties;

namespace OnlineBusinessAnalystCrawler
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var threadManager = new CrawlerThreadManager(Settings.Default.StartingURL,
                                                         Settings.Default.URLRegEx,
                                                         Settings.Default.ContentRegEx,
                                                         Settings.Default.MaxWebThreads,
                                                         Settings.Default.RequestTimeOut,
                                                         Settings.Default.SearchTimeout,
                                                         Settings.Default.DownloadTimeout,
                                                         Settings.Default.SaveBuffer,
                                                         Settings.Default.StorageInfo);
            threadManager.Start();
        }
    }
}
