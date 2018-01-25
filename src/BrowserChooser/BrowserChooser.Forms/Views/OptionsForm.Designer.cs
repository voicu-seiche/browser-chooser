namespace BrowserChooser.Forms.Views
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.Label1 = new System.Windows.Forms.Label();
            this.Browser1FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbRevealURL = new System.Windows.Forms.CheckBox();
            this.cbPortable = new System.Windows.Forms.CheckBox();
            this.btnUpdateCheck = new System.Windows.Forms.Button();
            this.cbAutoCheck = new System.Windows.Forms.CheckBox();
            this.btnSetDefault = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Browser2FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Browser3FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Browser4FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.ComboBox2 = new System.Windows.Forms.ComboBox();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.TextBox3 = new System.Windows.Forms.TextBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.TextBox4 = new System.Windows.Forms.TextBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.Browser5FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(364, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Use the following tabs to set up what browsers to choose from:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(221, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbRevealURL
            // 
            this.cbRevealURL.AutoSize = true;
            this.cbRevealURL.Location = new System.Drawing.Point(15, 75);
            this.cbRevealURL.Name = "cbRevealURL";
            this.cbRevealURL.Size = new System.Drawing.Size(142, 17);
            this.cbRevealURL.TabIndex = 19;
            this.cbRevealURL.Text = "Reveal Shortened URLs";
            this.cbRevealURL.UseVisualStyleBackColor = true;
            // 
            // cbPortable
            // 
            this.cbPortable.AutoSize = true;
            this.cbPortable.Location = new System.Drawing.Point(15, 52);
            this.cbPortable.Name = "cbPortable";
            this.cbPortable.Size = new System.Drawing.Size(94, 17);
            this.cbPortable.TabIndex = 4;
            this.cbPortable.Text = "Portable mode";
            this.cbPortable.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCheck
            // 
            this.btnUpdateCheck.Location = new System.Drawing.Point(301, 25);
            this.btnUpdateCheck.Name = "btnUpdateCheck";
            this.btnUpdateCheck.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCheck.TabIndex = 2;
            this.btnUpdateCheck.Text = "Check Now";
            this.btnUpdateCheck.UseVisualStyleBackColor = true;
            this.btnUpdateCheck.Click += new System.EventHandler(this.btnUpdateCheck_Click);
            // 
            // cbAutoCheck
            // 
            this.cbAutoCheck.AutoSize = true;
            this.cbAutoCheck.Location = new System.Drawing.Point(15, 29);
            this.cbAutoCheck.Name = "cbAutoCheck";
            this.cbAutoCheck.Size = new System.Drawing.Size(180, 17);
            this.cbAutoCheck.TabIndex = 1;
            this.cbAutoCheck.Text = "Automatically Check for Updates";
            this.cbAutoCheck.UseVisualStyleBackColor = true;
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSetDefault.Location = new System.Drawing.Point(15, 98);
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(361, 23);
            this.btnSetDefault.TabIndex = 0;
            this.btnSetDefault.Text = "Activate Browser Chooser (Make Default Browser)";
            this.btnSetDefault.UseVisualStyleBackColor = true;
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(328, 6);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(67, 17);
            this.CheckBox1.TabIndex = 32;
            this.CheckBox1.Text = "Disabled";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // ComboBox1
            // 
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "Firefox",
            "Flock",
            "Internet Explorer",
            "Opera",
            "Safari",
            "Google Chrome"});
            this.ComboBox1.Location = new System.Drawing.Point(275, 38);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(134, 21);
            this.ComboBox1.TabIndex = 33;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(6, 16);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(75, 13);
            this.Label14.TabIndex = 26;
            this.Label14.Text = "Display Name:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(272, 16);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(39, 13);
            this.Label15.TabIndex = 31;
            this.Label15.Text = "Image:";
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(53, 39);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(180, 20);
            this.TextBox1.TabIndex = 27;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(6, 42);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(41, 13);
            this.Label16.TabIndex = 30;
            this.Label16.Text = "Target:";
            // 
            // TextBox2
            // 
            this.TextBox2.Location = new System.Drawing.Point(84, 13);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(182, 20);
            this.TextBox2.TabIndex = 29;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(239, 36);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(27, 23);
            this.Button1.TabIndex = 28;
            this.Button1.Text = "...";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Location = new System.Drawing.Point(328, 6);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(67, 17);
            this.CheckBox2.TabIndex = 32;
            this.CheckBox2.Text = "Disabled";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // ComboBox2
            // 
            this.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox2.FormattingEnabled = true;
            this.ComboBox2.Items.AddRange(new object[] {
            "Firefox",
            "Flock",
            "Internet Explorer",
            "Opera",
            "Safari",
            "Google Chrome"});
            this.ComboBox2.Location = new System.Drawing.Point(275, 38);
            this.ComboBox2.Name = "ComboBox2";
            this.ComboBox2.Size = new System.Drawing.Size(134, 21);
            this.ComboBox2.TabIndex = 33;
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(6, 16);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(75, 13);
            this.Label17.TabIndex = 26;
            this.Label17.Text = "Display Name:";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(272, 16);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(39, 13);
            this.Label18.TabIndex = 31;
            this.Label18.Text = "Image:";
            // 
            // TextBox3
            // 
            this.TextBox3.Location = new System.Drawing.Point(53, 39);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.Size = new System.Drawing.Size(180, 20);
            this.TextBox3.TabIndex = 27;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(6, 42);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(41, 13);
            this.Label19.TabIndex = 30;
            this.Label19.Text = "Target:";
            // 
            // TextBox4
            // 
            this.TextBox4.Location = new System.Drawing.Point(84, 13);
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.Size = new System.Drawing.Size(182, 20);
            this.TextBox4.TabIndex = 29;
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(239, 36);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(27, 23);
            this.Button2.TabIndex = 28;
            this.Button2.Text = "...";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbRevealURL);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cbPortable);
            this.Controls.Add(this.btnUpdateCheck);
            this.Controls.Add(this.btnSetDefault);
            this.Controls.Add(this.cbAutoCheck);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog Browser1FileDialog;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.OpenFileDialog Browser2FileDialog;
        internal System.Windows.Forms.OpenFileDialog Browser3FileDialog;
        internal System.Windows.Forms.OpenFileDialog Browser4FileDialog;
        internal System.Windows.Forms.Button btnSetDefault;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.CheckBox CheckBox2;
        internal System.Windows.Forms.ComboBox ComboBox2;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox TextBox3;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.TextBox TextBox4;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.OpenFileDialog Browser5FileDialog;
        internal System.Windows.Forms.Button btnUpdateCheck;
        internal System.Windows.Forms.CheckBox cbAutoCheck;
        internal System.Windows.Forms.CheckBox cbPortable;
        internal System.Windows.Forms.CheckBox cbRevealURL;
    }
}