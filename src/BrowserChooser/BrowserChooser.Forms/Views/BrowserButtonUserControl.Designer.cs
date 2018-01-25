namespace BrowserChooser.Forms.Views
{
    partial class BrowserButtonUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browserIconPictureBox = new System.Windows.Forms.PictureBox();
            this.browserTitleLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.browserIconPictureBox)).BeginInit();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserIconPictureBox
            // 
            this.browserIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.browserIconPictureBox.Location = new System.Drawing.Point(0, 0);
            this.browserIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.browserIconPictureBox.Name = "browserIconPictureBox";
            this.browserIconPictureBox.Size = new System.Drawing.Size(36, 36);
            this.browserIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.browserIconPictureBox.TabIndex = 0;
            this.browserIconPictureBox.TabStop = false;
            this.browserIconPictureBox.Click += new System.EventHandler(this.BrowserButtonUserControl_Click);
            this.browserIconPictureBox.MouseLeave += new System.EventHandler(this.BrowserButtonUserControl_MouseLeave);
            this.browserIconPictureBox.MouseHover += new System.EventHandler(this.BrowserButtonUserControl_MouseHover);
            // 
            // browserTitleLabel
            // 
            this.browserTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserTitleLabel.AutoEllipsis = true;
            this.browserTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browserTitleLabel.Location = new System.Drawing.Point(36, 0);
            this.browserTitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.browserTitleLabel.Name = "browserTitleLabel";
            this.browserTitleLabel.Size = new System.Drawing.Size(220, 36);
            this.browserTitleLabel.TabIndex = 1;
            this.browserTitleLabel.Text = "aaa";
            this.browserTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browserTitleLabel.Click += new System.EventHandler(this.BrowserButtonUserControl_Click);
            this.browserTitleLabel.MouseLeave += new System.EventHandler(this.BrowserButtonUserControl_MouseLeave);
            this.browserTitleLabel.MouseHover += new System.EventHandler(this.BrowserButtonUserControl_MouseHover);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.Controls.Add(this.browserIconPictureBox);
            this.flowLayoutPanel.Controls.Add(this.browserTitleLabel);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(256, 36);
            this.flowLayoutPanel.TabIndex = 2;
            // 
            // BrowserButtonUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "BrowserButtonUserControl";
            this.Size = new System.Drawing.Size(256, 36);
            this.Load += new System.EventHandler(this.BrowserButtonUserControl_Load);
            this.Click += new System.EventHandler(this.BrowserButtonUserControl_Click);
            this.MouseLeave += new System.EventHandler(this.BrowserButtonUserControl_MouseLeave);
            this.MouseHover += new System.EventHandler(this.BrowserButtonUserControl_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.browserIconPictureBox)).EndInit();
            this.flowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox browserIconPictureBox;
        private System.Windows.Forms.Label browserTitleLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
    }
}
