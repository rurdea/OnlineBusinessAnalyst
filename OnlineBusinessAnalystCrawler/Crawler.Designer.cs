using MetroFramework.Controls;
namespace OnlineBusinessAnalystCrawler
{
    partial class Crawler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crawler));
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabProcesses = new System.Windows.Forms.TabPage();
            this.treeViewUrls = new System.Windows.Forms.TreeView();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSaveSettings = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadSettings = new MetroFramework.Controls.MetroButton();
            this.tbBrowseSettings = new System.Windows.Forms.TextBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.settingNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settingValueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serializeAsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfigSettingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPause = new MetroFramework.Controls.MetroButton();
            this.btnStop = new MetroFramework.Controls.MetroButton();
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.lblSettingStatus = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabProcesses.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigSettingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabProcesses);
            this.tabControl.Controls.Add(this.tabSettings);
            this.tabControl.ItemSize = new System.Drawing.Size(142, 44);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(747, 427);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.UseSelectable = true;
            // 
            // tabProcesses
            // 
            this.tabProcesses.Controls.Add(this.treeViewUrls);
            this.tabProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabProcesses.ImageIndex = 0;
            this.tabProcesses.Location = new System.Drawing.Point(4, 48);
            this.tabProcesses.Name = "tabProcesses";
            this.tabProcesses.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcesses.Size = new System.Drawing.Size(739, 375);
            this.tabProcesses.TabIndex = 0;
            this.tabProcesses.Text = "Processes";
            this.tabProcesses.UseVisualStyleBackColor = true;
            // 
            // treeViewUrls
            // 
            this.treeViewUrls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewUrls.Location = new System.Drawing.Point(3, 3);
            this.treeViewUrls.Name = "treeViewUrls";
            this.treeViewUrls.Size = new System.Drawing.Size(733, 369);
            this.treeViewUrls.TabIndex = 0;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.splitContainer1);
            this.tabSettings.ImageIndex = 0;
            this.tabSettings.Location = new System.Drawing.Point(4, 48);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(739, 375);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.btnSaveSettings);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnLoadSettings);
            this.splitContainer1.Panel1.Controls.Add(this.tbBrowseSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.metroGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(733, 369);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(641, 7);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(89, 24);
            this.btnSaveSettings.TabIndex = 2;
            this.btnSaveSettings.Text = "Save";
            this.btnSaveSettings.UseSelectable = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current settings:";
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSettings.Location = new System.Drawing.Point(546, 7);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(89, 24);
            this.btnLoadSettings.TabIndex = 1;
            this.btnLoadSettings.Text = "Load";
            this.btnLoadSettings.UseSelectable = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // tbBrowseSettings
            // 
            this.tbBrowseSettings.Location = new System.Drawing.Point(171, 7);
            this.tbBrowseSettings.Name = "tbBrowseSettings";
            this.tbBrowseSettings.ReadOnly = true;
            this.tbBrowseSettings.Size = new System.Drawing.Size(322, 20);
            this.tbBrowseSettings.TabIndex = 0;
            this.tbBrowseSettings.Visible = false;
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.settingNameDataGridViewTextBoxColumn1,
            this.settingValueDataGridViewTextBoxColumn1,
            this.serializeAsDataGridViewTextBoxColumn1});
            this.metroGrid1.DataSource = this.ConfigSettingsBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroGrid1.Location = new System.Drawing.Point(0, 0);
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Size = new System.Drawing.Size(733, 325);
            this.metroGrid1.TabIndex = 1;
            this.metroGrid1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // settingNameDataGridViewTextBoxColumn1
            // 
            this.settingNameDataGridViewTextBoxColumn1.DataPropertyName = "SettingName";
            this.settingNameDataGridViewTextBoxColumn1.HeaderText = "SettingName";
            this.settingNameDataGridViewTextBoxColumn1.Name = "settingNameDataGridViewTextBoxColumn1";
            // 
            // settingValueDataGridViewTextBoxColumn1
            // 
            this.settingValueDataGridViewTextBoxColumn1.DataPropertyName = "SettingValue";
            this.settingValueDataGridViewTextBoxColumn1.HeaderText = "SettingValue";
            this.settingValueDataGridViewTextBoxColumn1.Name = "settingValueDataGridViewTextBoxColumn1";
            // 
            // serializeAsDataGridViewTextBoxColumn1
            // 
            this.serializeAsDataGridViewTextBoxColumn1.DataPropertyName = "SerializeAs";
            this.serializeAsDataGridViewTextBoxColumn1.HeaderText = "SerializeAs";
            this.serializeAsDataGridViewTextBoxColumn1.Name = "serializeAsDataGridViewTextBoxColumn1";
            // 
            // ConfigSettingsBindingSource
            // 
            this.ConfigSettingsBindingSource.DataSource = typeof(OnlineBusinessAnalystCrawler.Model.SettingsModel);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Tree32.png");
            this.imageList.Images.SetKeyName(1, "Pause32.png");
            this.imageList.Images.SetKeyName(2, "Start32.png");
            this.imageList.Images.SetKeyName(3, "Stop32.png");
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(20, 60);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl);
            this.splitContainer2.Size = new System.Drawing.Size(747, 495);
            this.splitContainer2.SplitterDistance = 61;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.btnPause);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.lblSettingStatus);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control pannel";
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(218, 25);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(87, 29);
            this.btnPause.TabIndex = 3;
            this.btnPause.Text = "Pause";
            this.btnPause.UseSelectable = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(125, 25);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(87, 29);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseSelectable = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(32, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 29);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseSelectable = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblSettingStatus
            // 
            this.lblSettingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSettingStatus.AutoSize = true;
            this.lblSettingStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSettingStatus.Location = new System.Drawing.Point(311, 25);
            this.lblSettingStatus.Name = "lblSettingStatus";
            this.lblSettingStatus.Size = new System.Drawing.Size(254, 20);
            this.lblSettingStatus.TabIndex = 0;
            this.lblSettingStatus.Text = "Settings status: no settings loaded";
            // 
            // Crawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 575);
            this.Controls.Add(this.splitContainer2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(787, 575);
            this.MinimumSize = new System.Drawing.Size(787, 575);
            this.Name = "Crawler";
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "Online Business AnalystCrawler";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl.ResumeLayout(false);
            this.tabProcesses.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigSettingsBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabProcesses;
        private System.Windows.Forms.TabPage tabSettings;

        private System.Windows.Forms.TreeView treeViewUrls;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBrowseSettings;
        public System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSettingStatus;
        private System.Windows.Forms.BindingSource ConfigSettingsBindingSource;
        private MetroGrid metroGrid1;
        private System.Windows.Forms.DataGridViewTextBoxColumn settingNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn settingValueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serializeAsDataGridViewTextBoxColumn1;
        private MetroButton btnLoadSettings;
        private MetroButton btnSaveSettings;
        private MetroButton btnPause;
        private MetroButton btnStop;
        private MetroButton btnStart;
    }
}

