namespace PlutoniumPlus
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
            this.textBoxPLInstallLocation = new System.Windows.Forms.TextBox();
            this.plInstallDirectoryButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.buttonMovePLInstall = new System.Windows.Forms.Button();
            this.buttonCreateShortcut = new System.Windows.Forms.Button();
            this.checkBoxAutoClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxPLInstallLocation
            // 
            this.textBoxPLInstallLocation.Location = new System.Drawing.Point(12, 12);
            this.textBoxPLInstallLocation.Name = "textBoxPLInstallLocation";
            this.textBoxPLInstallLocation.Size = new System.Drawing.Size(209, 20);
            this.textBoxPLInstallLocation.TabIndex = 0;
            // 
            // plInstallDirectoryButton
            // 
            this.plInstallDirectoryButton.Location = new System.Drawing.Point(12, 38);
            this.plInstallDirectoryButton.Name = "plInstallDirectoryButton";
            this.plInstallDirectoryButton.Size = new System.Drawing.Size(209, 23);
            this.plInstallDirectoryButton.TabIndex = 1;
            this.plInstallDirectoryButton.Text = "Select/Set Plutonium Client Directory";
            this.plInstallDirectoryButton.UseVisualStyleBackColor = true;
            this.plInstallDirectoryButton.Click += new System.EventHandler(this.plInstallDirectoryButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(12, 160);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(92, 23);
            this.saveSettingsButton.TabIndex = 2;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(123, 160);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(98, 23);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // buttonMovePLInstall
            // 
            this.buttonMovePLInstall.Location = new System.Drawing.Point(12, 67);
            this.buttonMovePLInstall.Name = "buttonMovePLInstall";
            this.buttonMovePLInstall.Size = new System.Drawing.Size(209, 23);
            this.buttonMovePLInstall.TabIndex = 4;
            this.buttonMovePLInstall.Text = "Move Current Plutonium Client Install";
            this.buttonMovePLInstall.UseVisualStyleBackColor = true;
            this.buttonMovePLInstall.Click += new System.EventHandler(this.buttonMovePLInstall_Click);
            // 
            // buttonCreateShortcut
            // 
            this.buttonCreateShortcut.Location = new System.Drawing.Point(12, 131);
            this.buttonCreateShortcut.Name = "buttonCreateShortcut";
            this.buttonCreateShortcut.Size = new System.Drawing.Size(92, 23);
            this.buttonCreateShortcut.TabIndex = 5;
            this.buttonCreateShortcut.Text = "Create Shortcut";
            this.buttonCreateShortcut.UseVisualStyleBackColor = true;
            this.buttonCreateShortcut.Click += new System.EventHandler(this.buttonCreateShortcut_Click);
            // 
            // checkBoxAutoClose
            // 
            this.checkBoxAutoClose.AutoSize = true;
            this.checkBoxAutoClose.Location = new System.Drawing.Point(12, 108);
            this.checkBoxAutoClose.Name = "checkBoxAutoClose";
            this.checkBoxAutoClose.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAutoClose.TabIndex = 6;
            this.checkBoxAutoClose.Text = "Auto Close on Launch";
            this.checkBoxAutoClose.UseVisualStyleBackColor = true;
            this.checkBoxAutoClose.CheckedChanged += new System.EventHandler(this.checkBoxAutoClose_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 195);
            this.Controls.Add(this.checkBoxAutoClose);
            this.Controls.Add(this.buttonCreateShortcut);
            this.Controls.Add(this.buttonMovePLInstall);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.plInstallDirectoryButton);
            this.Controls.Add(this.textBoxPLInstallLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PlutoniumPlus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPLInstallLocation;
        private System.Windows.Forms.Button plInstallDirectoryButton;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button buttonMovePLInstall;
        private System.Windows.Forms.Button buttonCreateShortcut;
        private System.Windows.Forms.CheckBox checkBoxAutoClose;
    }
}

