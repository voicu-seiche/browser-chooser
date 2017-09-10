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
            this.btnInfo = new System.Windows.Forms.PictureBox();
            this.btnApp1 = new System.Windows.Forms.PictureBox();
            this.browserButtonContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddUrlToAutoOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyUrlToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOptions = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApp2 = new System.Windows.Forms.PictureBox();
            this.btnApp3 = new System.Windows.Forms.PictureBox();
            this.btnApp4 = new System.Windows.Forms.PictureBox();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.btnApp5 = new System.Windows.Forms.PictureBox();
            this.btn1TT = new System.Windows.Forms.ToolTip(this.components);
            this.btn2TT = new System.Windows.Forms.ToolTip(this.components);
            this.btn3TT = new System.Windows.Forms.ToolTip(this.components);
            this.btn4TT = new System.Windows.Forms.ToolTip(this.components);
            this.btn5TT = new System.Windows.Forms.ToolTip(this.components);
            this.RememberForThisURL = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp1)).BeginInit();
            this.browserButtonContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.Image = global::BrowserChooser.Forms.Properties.Resources._122;
            this.btnInfo.Location = new System.Drawing.Point(12, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(16, 16);
            this.btnInfo.TabIndex = 0;
            this.btnInfo.TabStop = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            this.btnInfo.MouseEnter += new System.EventHandler(this.btnInfo_MouseEnter);
            this.btnInfo.MouseLeave += new System.EventHandler(this.btnInfo_MouseLeave);
            // 
            // btnApp1
            // 
            this.btnApp1.BackColor = System.Drawing.Color.Transparent;
            this.btnApp1.ContextMenuStrip = this.browserButtonContextMenu;
            this.btnApp1.Image = global::BrowserChooser.Forms.Properties.Resources.Firefox;
            this.btnApp1.Location = new System.Drawing.Point(56, 1);
            this.btnApp1.Name = "btnApp1";
            this.btnApp1.Size = new System.Drawing.Size(75, 80);
            this.btnApp1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnApp1.TabIndex = 2;
            this.btnApp1.TabStop = false;
            this.btnApp1.Visible = false;
            this.btnApp1.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp1.MouseEnter += new System.EventHandler(this.btnApp_MouseHover);
            this.btnApp1.MouseLeave += new System.EventHandler(this.btnApp_MouseLeave);
            this.btnApp1.MouseHover += new System.EventHandler(this.btnApp_MouseHover);
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
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnOptions.Image = global::BrowserChooser.Forms.Properties.Resources._128;
            this.btnOptions.Location = new System.Drawing.Point(478, 12);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(16, 16);
            this.btnOptions.TabIndex = 5;
            this.btnOptions.TabStop = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            this.btnOptions.MouseEnter += new System.EventHandler(this.btnOptions_MouseEnter);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(370, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(0, 0);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnApp2
            // 
            this.btnApp2.BackColor = System.Drawing.Color.Transparent;
            this.btnApp2.ContextMenuStrip = this.browserButtonContextMenu;
            this.btnApp2.Image = global::BrowserChooser.Forms.Properties.Resources.InternetExplorer;
            this.btnApp2.Location = new System.Drawing.Point(137, 1);
            this.btnApp2.Name = "btnApp2";
            this.btnApp2.Size = new System.Drawing.Size(75, 80);
            this.btnApp2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnApp2.TabIndex = 7;
            this.btnApp2.TabStop = false;
            this.btnApp2.Visible = false;
            this.btnApp2.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp2.MouseEnter += new System.EventHandler(this.btnApp_MouseHover);
            this.btnApp2.MouseLeave += new System.EventHandler(this.btnApp_MouseLeave);
            this.btnApp2.MouseHover += new System.EventHandler(this.btnApp_MouseHover);
            // 
            // btnApp3
            // 
            this.btnApp3.BackColor = System.Drawing.Color.Transparent;
            this.btnApp3.ContextMenuStrip = this.browserButtonContextMenu;
            this.btnApp3.Image = global::BrowserChooser.Forms.Properties.Resources.GoogleChrome;
            this.btnApp3.Location = new System.Drawing.Point(218, 1);
            this.btnApp3.Name = "btnApp3";
            this.btnApp3.Size = new System.Drawing.Size(75, 80);
            this.btnApp3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnApp3.TabIndex = 8;
            this.btnApp3.TabStop = false;
            this.btnApp3.Visible = false;
            this.btnApp3.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp3.MouseEnter += new System.EventHandler(this.btnApp_MouseHover);
            this.btnApp3.MouseLeave += new System.EventHandler(this.btnApp_MouseLeave);
            this.btnApp3.MouseHover += new System.EventHandler(this.btnApp_MouseHover);
            // 
            // btnApp4
            // 
            this.btnApp4.BackColor = System.Drawing.Color.Transparent;
            this.btnApp4.ContextMenuStrip = this.browserButtonContextMenu;
            this.btnApp4.Image = global::BrowserChooser.Forms.Properties.Resources.Safari;
            this.btnApp4.Location = new System.Drawing.Point(299, 1);
            this.btnApp4.Name = "btnApp4";
            this.btnApp4.Size = new System.Drawing.Size(75, 80);
            this.btnApp4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnApp4.TabIndex = 9;
            this.btnApp4.TabStop = false;
            this.btnApp4.Visible = false;
            this.btnApp4.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp4.MouseEnter += new System.EventHandler(this.btnApp_MouseHover);
            this.btnApp4.MouseLeave += new System.EventHandler(this.btnApp_MouseLeave);
            this.btnApp4.MouseHover += new System.EventHandler(this.btnApp_MouseHover);
            // 
            // lblEmpty
            // 
            this.lblEmpty.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblEmpty.Location = new System.Drawing.Point(60, 29);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(392, 23);
            this.lblEmpty.TabIndex = 10;
            this.lblEmpty.Text = "Please choose your browsers in the options!";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            // 
            // btnApp5
            // 
            this.btnApp5.BackColor = System.Drawing.Color.Transparent;
            this.btnApp5.ContextMenuStrip = this.browserButtonContextMenu;
            this.btnApp5.Image = global::BrowserChooser.Forms.Properties.Resources.Safari;
            this.btnApp5.Location = new System.Drawing.Point(380, 1);
            this.btnApp5.Name = "btnApp5";
            this.btnApp5.Size = new System.Drawing.Size(75, 80);
            this.btnApp5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnApp5.TabIndex = 11;
            this.btnApp5.TabStop = false;
            this.btnApp5.Visible = false;
            this.btnApp5.Click += new System.EventHandler(this.btnApp_Click);
            this.btnApp5.MouseEnter += new System.EventHandler(this.btnApp_MouseHover);
            this.btnApp5.MouseLeave += new System.EventHandler(this.btnApp_MouseLeave);
            this.btnApp5.MouseHover += new System.EventHandler(this.btnApp_MouseHover);
            // 
            // RememberForThisURL
            // 
            this.RememberForThisURL.AutoSize = true;
            this.RememberForThisURL.Location = new System.Drawing.Point(56, 88);
            this.RememberForThisURL.Name = "RememberForThisURL";
            this.RememberForThisURL.Size = new System.Drawing.Size(197, 17);
            this.RememberForThisURL.TabIndex = 12;
            this.RememberForThisURL.Text = "Remember my selection for this URL";
            this.RememberForThisURL.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(501, 110);
            this.Controls.Add(this.RememberForThisURL);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.btnApp5);
            this.Controls.Add(this.btnApp4);
            this.Controls.Add(this.btnApp3);
            this.Controls.Add(this.btnApp2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnApp1);
            this.Controls.Add(this.btnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose a Browser";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp1)).EndInit();
            this.browserButtonContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApp5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox btnInfo;
        internal System.Windows.Forms.PictureBox btnApp1;
        internal System.Windows.Forms.PictureBox btnOptions;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.PictureBox btnApp2;
        internal System.Windows.Forms.PictureBox btnApp3;
        internal System.Windows.Forms.PictureBox btnApp4;
        internal System.Windows.Forms.Label lblEmpty;
        internal System.Windows.Forms.PictureBox btnApp5;
        internal System.Windows.Forms.ToolTip btn1TT;
        internal System.Windows.Forms.ToolTip btn2TT;
        internal System.Windows.Forms.ToolTip btn3TT;
        internal System.Windows.Forms.ToolTip btn4TT;
        internal System.Windows.Forms.ToolTip btn5TT;
        internal System.Windows.Forms.ContextMenuStrip browserButtonContextMenu;
        internal System.Windows.Forms.ToolStripMenuItem AddUrlToAutoOpenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem CopyUrlToClipboardToolStripMenuItem;
        internal CheckBox RememberForThisURL;
    }
}

