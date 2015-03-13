using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OnlineBusinessAnalystCrawler
{
    public partial class Crawler : Form
    {

        public Crawler()
        {
            InitializeComponent();
            //tbBrowseSettings.Text = path;
            //rtbSettings.Text = File.ReadAllText(path);
            UpdateSettingStatus();
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
        #endregion



        #region Start Stop Pause
        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnPause_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
