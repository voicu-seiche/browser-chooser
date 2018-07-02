using System.Windows.Forms;

namespace BrowserChooser.Forms.Views
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rememberUrlCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.urlPanel = new System.Windows.Forms.Panel();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTitleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.urlPanel.SuspendLayout();
            this.settingsPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rememberUrlCheckBox
            // 
            this.rememberUrlCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rememberUrlCheckBox.AutoSize = true;
            this.rememberUrlCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberUrlCheckBox.Location = new System.Drawing.Point(7, 6);
            this.rememberUrlCheckBox.Name = "rememberUrlCheckBox";
            this.rememberUrlCheckBox.Size = new System.Drawing.Size(257, 21);
            this.rememberUrlCheckBox.TabIndex = 12;
            this.rememberUrlCheckBox.TabStop = false;
            this.rememberUrlCheckBox.Text = "&Remember my selection for this URL";
            this.rememberUrlCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 115);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(270, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 13;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // urlPanel
            // 
            this.urlPanel.Controls.Add(this.urlLabel);
            this.urlPanel.Controls.Add(this.urlTitleLabel);
            this.urlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.urlPanel.Location = new System.Drawing.Point(0, 24);
            this.urlPanel.Name = "urlPanel";
            this.urlPanel.Size = new System.Drawing.Size(270, 26);
            this.urlPanel.TabIndex = 15;
            // 
            // urlLabel
            // 
            this.urlLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlLabel.AutoEllipsis = true;
            this.urlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlLabel.Location = new System.Drawing.Point(49, 3);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(209, 24);
            this.urlLabel.TabIndex = 14;
            this.urlLabel.Text = "aaa";
            // 
            // urlTitleLabel
            // 
            this.urlTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.urlTitleLabel.AutoSize = true;
            this.urlTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlTitleLabel.Location = new System.Drawing.Point(3, 3);
            this.urlTitleLabel.Name = "urlTitleLabel";
            this.urlTitleLabel.Size = new System.Drawing.Size(50, 20);
            this.urlTitleLabel.TabIndex = 13;
            this.urlTitleLabel.Text = "URL:";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(270, 32);
            this.flowLayoutPanel.TabIndex = 16;
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.rememberUrlCheckBox);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsPanel.Location = new System.Drawing.Point(0, 82);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(270, 33);
            this.settingsPanel.TabIndex = 0;
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(270, 24);
            this.menuStrip.TabIndex = 17;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.copyToolStripMenuItem.Text = "&Copy URL to clipboard";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for &updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(270, 137);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.urlPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a browser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.urlPanel.ResumeLayout(false);
            this.urlPanel.PerformLayout();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal CheckBox rememberUrlCheckBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Panel urlPanel;
        private Label urlTitleLabel;
        private Label urlLabel;
        private FlowLayoutPanel flowLayoutPanel;
        private Panel settingsPanel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
    }
}

