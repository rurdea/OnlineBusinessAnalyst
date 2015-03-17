using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using OnlineBusinessAnalystCrawler.Model;
using MetroFramework.Forms;
using OnlineBusinessAnalystCrawler.Utils;
using OnlineBusinessAnalyst;
using OnlineBusinessAnalystCrawler.Properties;
using System.Diagnostics;
using System.Xml.Linq;

namespace OnlineBusinessAnalystCrawler
{
    public partial class Crawler : MetroForm
    {
        private CrawlerThreadManager threadManager = new CrawlerThreadManager(Settings.Default.StartingURL,
                                                         Settings.Default.URLRegEx,
                                                         Settings.Default.ContentRegEx,
                                                         Settings.Default.MaxWebThreads,
                                                         Settings.Default.RequestTimeOut,
                                                         Settings.Default.SearchTimeout,
                                                         Settings.Default.DownloadTimeout,
                                                         Settings.Default.SaveBuffer,
                                                         Settings.Default.StorageInfo);

        private string m_strSettingName;

        private List<DisplayNodeModel> urlsToDisplay = new List<DisplayNodeModel>();

        private List<SettingsModel> ConfigSettingsList = new List<SettingsModel>();

        public Crawler()
        {
            InitializeComponent();
            //tbBrowseSettings.Text = path;
            //rtbSettings.Text = File.ReadAllText(path);
            //UpdateSettingStatus();
            lblSettingStatus.Text = string.Format(Constants.SettingsMessageHeader, Constants.NoSettingsLoaded);

            LoadSettings();


        }


        #region Settings

        public void UpdateSettingStatus()
        {
            /*
            if (settings == null)
            {   lblSettingStatus.Text = "Settings status: no settings loaded!";
            return;}
            if (settings.corrrectSettings == false)
            {
                lblSettingStatus.Text = "Settings status: incorrect settings!";
                return;
            }
            lblSettingStatus.Text = "Settings status: "+settings.Title+" succesfully loaded!";
            btnStart.Enabled = true;
            */
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            LoadSettings();
            /*
            try
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Open Settings File";
                theDialog.Filter = "Conf files|*.conf";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    settings = new ApplicationSettings(theDialog.FileName);
                    tbBrowseSettings.Text = theDialog.FileName;
                    rtbSettings.Text = File.ReadAllText(theDialog.FileName);
                    UpdateSettingStatus();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ApplicationSettings.ErrorsLog);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
           */
        }


        private void btnSaveSettings_Click(object sender, EventArgs e)
        {

            UpdateSettings();
            /*
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "CustomSettings.conf";
                // set filters - this can be done in properties as well
                savefile.Filter = "Conf files (*.conf)|*.conf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Delete(savefile.FileName);
                    }
                    catch { }
                    File.WriteAllText(savefile.FileName,rtbSettings.Text);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, ApplicationSettings.ErrorsLog);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
             * */
        }


        private void LoadSettings()
        {
            try
            {
                string strFile = null;
                XmlDocument ConfigDoc = new XmlDocument();
                //Store the name of the file
                strFile = string.Format(Constants.SettingsContainer, Directory.GetCurrentDirectory().ToString());
                //Load the configuration file as XML document
                ConfigDoc.Load(strFile);
                //Assign  the [applicationSettings] node 
                XmlNode applicationSettingsNode = ConfigDoc.GetElementsByTagName("applicationSettings")[0];

                //For reading the user settings use below
                //Dim applicationSettingsNode As XmlNode = ConfigDoc.GetElementsByTagName("userSettings")(0)

                ConfigSettingsList.Clear();

                //Run for each child node and create the ConfigSettingsList collection of [applicationSettings] child nodes
                foreach (XmlNode objXmlNode in applicationSettingsNode.FirstChild.ChildNodes)
                {
                    var objConfigSettings = new SettingsModel();
                    var _with1 = objConfigSettings;
                    _with1.SettingName = objXmlNode.Attributes[0].Value;
                    _with1.SerializeAs = objXmlNode.Attributes[1].Value;
                    _with1.SettingValue = objXmlNode.FirstChild.InnerText;
                    ConfigSettingsList.Add(objConfigSettings);
                }

                //Assign the collection to Datasource
                ConfigSettingsBindingSource.DataSource = ConfigSettingsList;


                lblSettingStatus.Text = string.Format(Constants.SettingsMessageHeader, Constants.SettingsLoaded);
            }
            catch (Exception ex)
            {
                //TODO: Use log instead
                MetroFramework.MetroMessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSettings()
        {
            try
            {
                string strFile = null;
                XmlDocument ConfigDoc = new XmlDocument();
                strFile = string.Format(Constants.SettingsContainer, Directory.GetCurrentDirectory().ToString());
                ConfigDoc.Load(strFile);
                XmlNode applicationSettingsNode = ConfigDoc.GetElementsByTagName("applicationSettings")[0];

                //For reading the user settings use below
                //Dim applicationSettingsNode As XmlNode = ConfigDoc.GetElementsByTagName("userSettings")(0)



                foreach (XmlNode objXmlNode in applicationSettingsNode.FirstChild.ChildNodes)
                {
                    m_strSettingName = objXmlNode.Attributes[0].Value;

                    var objConfigSettings = ConfigSettingsList.Find(GetSetting);

                    if (objConfigSettings != null)
                    {
                        var _with1 = objConfigSettings;
                        objXmlNode.Attributes[0].Value = _with1.SettingName;
                        objXmlNode.Attributes[1].Value = _with1.SerializeAs;
                        objXmlNode.FirstChild.InnerText = _with1.SettingValue;
                    }
                }
                ConfigDoc.Save(strFile);
                MetroFramework.MetroMessageBox.Show(this, "Updated Successfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSettingStatus.Text = string.Format(Constants.SettingsMessageHeader, Constants.SettingsUpdated);
            }
            catch (Exception ex)
            {
                //TODO: Use log instead
                MetroFramework.MetroMessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool GetSetting(SettingsModel objConfigSettings)
        {
            return m_strSettingName == objConfigSettings.SettingName;
        }


        #endregion



        #region Start Stop Pause
        private void btnStart_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;

            btnStop.Enabled = true;
            btnPause.Enabled = true;
            btnStart.Enabled = false;

            threadManager = new CrawlerThreadManager(Settings.Default.StartingURL,
                                                         Settings.Default.URLRegEx,
                                                         Settings.Default.ContentRegEx,
                                                         Settings.Default.MaxWebThreads,
                                                         Settings.Default.RequestTimeOut,
                                                         Settings.Default.SearchTimeout,
                                                         Settings.Default.DownloadTimeout,
                                                         Settings.Default.SaveBuffer,
                                                         Settings.Default.StorageInfo);
            threadManager.CrawlStarted += threadManager_CrawlStarted;
            threadManager.CrawlProgressChanged += threadManager_CrawlProgressChanged;
            threadManager.CrawlCompleted += threadManager_CrawlCompleted;
            threadManager.Start();

        }

        void threadManager_CrawlCompleted(object sender, CrawlCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate { threadManager_CrawlCompleted(sender, e); };
                this.Invoke(del, sender, e);
                return;
            }

            var url = e.Url;

            var node = GetTreeNode(url);
            if (node != null)
            {
                UpdateNodeText(node, 100, e.Status);
            }

        }

        private delegate void ThreadManagerCrawlProgressChangedDelegate(object sender, ProgressChangedEventArgs e);

        void threadManager_CrawlProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                MethodInvoker del = delegate { threadManager_CrawlProgressChanged(sender, e); };
                this.Invoke(del, sender, e);
                return;
            }
            var url = ((CrawlerEventArgs)e.UserState).Url;

            Debug.WriteLine(url);

            var nodeToUpdate = GetTreeNode(url);
            if (nodeToUpdate != null)
            {
                UpdateNodeText(nodeToUpdate, e.ProgressPercentage, null);
            }
        }

        private delegate void ThreadManagerCrawlStartedDelegate(object sender, CrawlerEventArgs e);

        void threadManager_CrawlStarted(object sender, CrawlerEventArgs e)
        {
            var newUrl = new DisplayNodeModel()
                {
                    ParentUrl = e.ParentUrl,
                    Url = e.Url,
                    Progress = 0
                };

            if (!urlsToDisplay.Contains(newUrl))
            {
                urlsToDisplay.Add(newUrl);

                if (this.treeViewUrls.InvokeRequired)
                {
                    this.treeViewUrls.Invoke(new ThreadManagerCrawlStartedDelegate(this.threadManager_CrawlStarted), sender, e);
                }
                else
                {

                    try
                    {
                        treeViewUrls.BeginUpdate();

                        treeViewUrls.SuspendLayout();

                        if (string.IsNullOrEmpty(newUrl.ParentUrl))
                        {

                            treeViewUrls.Nodes.Clear();

                            var rootNode = new TreeNode()
                            {
                                Text = newUrl.Url,
                                Tag = newUrl.Url
                            };

                            treeViewUrls.Nodes.Add(rootNode);
                        }
                        else
                        {

                            var parent = GetTreeNode(newUrl.ParentUrl);
                            if (parent != null)
                            {
                                var childNode = new TreeNode()
                                {
                                    Text = newUrl.Url,
                                    Tag = newUrl.Url
                                };

                                childNode.EnsureVisible();

                                parent.Nodes.Add(childNode);
                            }
                        }
                    }
                    finally
                    {
                        treeViewUrls.ExpandAll();

                        treeViewUrls.ResumeLayout();
                        treeViewUrls.EndUpdate();
                    }
                }
            }

            Debug.WriteLine(e.Url);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            threadManager.Stop();

            tabControl.SelectedIndex = 0;

            btnStop.Enabled = false;
            btnPause.Enabled = false;
            btnStart.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;

            if (btnPause.Text == "Pause")
            {

                btnPause.Text = "Resume";
            }
            else
            {
                btnPause.Text = "Pause";
            }

            btnStop.Enabled = true;
            btnStart.Enabled = false;
        }

        private TreeNode GetTreeNode(string tag)
        {
            return treeViewUrls.GetAllNodes().FirstOrDefault(n => n.Tag.Equals(tag));
        }

        private void UpdateNodeText(TreeNode node, int percentage, bool? status)
        {
            node.Text = string.Format("{0} (Progress: {1}%, Status: {2} )", node.Tag.ToString(), percentage.ToString(), status.HasValue ? status.Value ? "OK" : "Error" : "");
        }
        #endregion

    }
}
