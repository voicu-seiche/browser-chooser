using System.Windows.Forms;

namespace BrowserChooser.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.browserButtonContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddUrlToAutoOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyUrlToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rememberUrlCheckBox = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.optionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.urlLabel = new System.Windows.Forms.Label();
            this.urlTitleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.browserButtonContextMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserButtonContextMenu
            // 
            this.browserButtonContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUrlToAutoOpenToolStripMenuItem,
            this.CopyUrlToClipboardToolStripMenuItem});
            this.browserButtonContextMenu.Name = "btn1ContextMenu";
            this.browserButtonContextMenu.Size = new System.Drawing.Size(213, 48);
            // 
            // AddUrlToAutoOpenToolStripMenuItem
            // 
            this.AddUrlToAutoOpenToolStripMenuItem.Name = "AddUrlToAutoOpenToolStripMenuItem";
            this.AddUrlToAutoOpenToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.AddUrlToAutoOpenToolStripMenuItem.Text = "Add Url To Auto Open List";
            this.AddUrlToAutoOpenToolStripMenuItem.Click += new System.EventHandler(this.AddUrlToAutoOpenToolStripMenuItem_Click);
            // 
            // CopyUrlToClipboardToolStripMenuItem
            // 
            this.CopyUrlToClipboardToolStripMenuItem.Name = "CopyUrlToClipboardToolStripMenuItem";
            this.CopyUrlToClipboardToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.CopyUrlToClipboardToolStripMenuItem.Text = "Copy Url To Clipboard";
            this.CopyUrlToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyUrlToClipboardToolStripMenuItem_Click);
            // 
            // rememberUrlCheckBox
            // 
            this.rememberUrlCheckBox.AutoSize = true;
            this.rememberUrlCheckBox.Location = new System.Drawing.Point(53, 26);
            this.rememberUrlCheckBox.Name = "rememberUrlCheckBox";
            this.rememberUrlCheckBox.Size = new System.Drawing.Size(197, 17);
            this.rememberUrlCheckBox.TabIndex = 12;
            this.rememberUrlCheckBox.Text = "Remember my selection for this URL";
            this.rememberUrlCheckBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 144);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(579, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 13;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripButton,
            this.toolStripSeparator1,
            this.aboutToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(579, 25);
            this.toolStrip.TabIndex = 14;
            // 
            // optionsToolStripButton
            // 
            this.optionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optionsToolStripButton.Image = global::BrowserChooser.Forms.Properties.Resources._128;
            this.optionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsToolStripButton.Name = "optionsToolStripButton";
            this.optionsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.optionsToolStripButton.Text = "Options";
            this.optionsToolStripButton.Click += new System.EventHandler(this.optionsToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutToolStripButton
            // 
            this.aboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutToolStripButton.Image = global::BrowserChooser.Forms.Properties.Resources._122;
            this.aboutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutToolStripButton.Name = "aboutToolStripButton";
            this.aboutToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.aboutToolStripButton.Text = "About";
            this.aboutToolStripButton.Click += new System.EventHandler(this.aboutToolStripButton_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.urlLabel);
            this.infoPanel.Controls.Add(this.urlTitleLabel);
            this.infoPanel.Controls.Add(this.rememberUrlCheckBox);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 25);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(579, 55);
            this.infoPanel.TabIndex = 15;
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(50, 10);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(0, 13);
            this.urlLabel.TabIndex = 14;
            // 
            // urlTitleLabel
            // 
            this.urlTitleLabel.AutoSize = true;
            this.urlTitleLabel.Location = new System.Drawing.Point(12, 10);
            this.urlTitleLabel.Name = "urlTitleLabel";
            this.urlTitleLabel.Size = new System.Drawing.Size(32, 13);
            this.urlTitleLabel.TabIndex = 13;
            this.urlTitleLabel.Text = "URL:";
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(579, 64);
            this.flowLayoutPanel.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(579, 166);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a Browser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.browserButtonContextMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ContextMenuStrip browserButtonContextMenu;
        internal System.Windows.Forms.ToolStripMenuItem AddUrlToAutoOpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CopyUrlToClipboardToolStripMenuItem;
        internal CheckBox rememberUrlCheckBox;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ToolStrip toolStrip;
        private ToolStripButton optionsToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton aboutToolStripButton;
        private Panel infoPanel;
        private Label urlTitleLabel;
        private Label urlLabel;
        private FlowLayoutPanel flowLayoutPanel;
    }
}

