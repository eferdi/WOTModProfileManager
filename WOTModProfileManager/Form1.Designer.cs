namespace WoTModProfileManager
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.groupBoxProfileFolder = new System.Windows.Forms.GroupBox();
            this.treeViewProfileFolder = new System.Windows.Forms.TreeView();
            this.buttonProfileDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxProfileNotes = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelLauncherVersionNumber = new System.Windows.Forms.Label();
            this.labelLauchnerVersion = new System.Windows.Forms.Label();
            this.labelGameVersionNumber = new System.Windows.Forms.Label();
            this.labelGameVersion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStartWOTWOMods = new System.Windows.Forms.Button();
            this.buttonStartWOTWMods = new System.Windows.Forms.Button();
            this.buttonProfileNew = new System.Windows.Forms.Button();
            this.comboBoxProfiles = new System.Windows.Forms.ComboBox();
            this.labelProfile = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.tabLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.tabContainer.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.groupBoxProfileFolder.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabLog.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tabMain);
            this.tabContainer.Controls.Add(this.tabSettings);
            this.tabContainer.Controls.Add(this.tabLog);
            this.tabContainer.Controls.Add(this.tabAbout);
            this.tabContainer.Location = new System.Drawing.Point(13, 13);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(519, 574);
            this.tabContainer.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.groupBoxProfileFolder);
            this.tabMain.Controls.Add(this.buttonProfileDelete);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.groupBox2);
            this.tabMain.Controls.Add(this.groupBox1);
            this.tabMain.Controls.Add(this.buttonProfileNew);
            this.tabMain.Controls.Add(this.comboBoxProfiles);
            this.tabMain.Controls.Add(this.labelProfile);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(511, 548);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // groupBoxProfileFolder
            // 
            this.groupBoxProfileFolder.Controls.Add(this.treeViewProfileFolder);
            this.groupBoxProfileFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProfileFolder.Location = new System.Drawing.Point(9, 52);
            this.groupBoxProfileFolder.Name = "groupBoxProfileFolder";
            this.groupBoxProfileFolder.Size = new System.Drawing.Size(262, 484);
            this.groupBoxProfileFolder.TabIndex = 14;
            this.groupBoxProfileFolder.TabStop = false;
            this.groupBoxProfileFolder.Text = "Profile Folder";
            // 
            // treeViewProfileFolder
            // 
            this.treeViewProfileFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewProfileFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewProfileFolder.Location = new System.Drawing.Point(9, 19);
            this.treeViewProfileFolder.Name = "treeViewProfileFolder";
            this.treeViewProfileFolder.Size = new System.Drawing.Size(242, 456);
            this.treeViewProfileFolder.TabIndex = 0;
            // 
            // buttonProfileDelete
            // 
            this.buttonProfileDelete.Location = new System.Drawing.Point(443, 11);
            this.buttonProfileDelete.Name = "buttonProfileDelete";
            this.buttonProfileDelete.Size = new System.Drawing.Size(56, 22);
            this.buttonProfileDelete.TabIndex = 13;
            this.buttonProfileDelete.Text = "delete";
            this.buttonProfileDelete.UseVisualStyleBackColor = true;
            this.buttonProfileDelete.Click += new System.EventHandler(this.buttonProfileDelete_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(490, 3);
            this.label1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxProfileNotes);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(279, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 345);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile Notes";
            // 
            // richTextBoxProfileNotes
            // 
            this.richTextBoxProfileNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxProfileNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxProfileNotes.Location = new System.Drawing.Point(9, 17);
            this.richTextBoxProfileNotes.Name = "richTextBoxProfileNotes";
            this.richTextBoxProfileNotes.Size = new System.Drawing.Size(205, 322);
            this.richTextBoxProfileNotes.TabIndex = 0;
            this.richTextBoxProfileNotes.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelLauncherVersionNumber);
            this.groupBox1.Controls.Add(this.labelLauchnerVersion);
            this.groupBox1.Controls.Add(this.labelGameVersionNumber);
            this.groupBox1.Controls.Add(this.labelGameVersion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.buttonStartWOTWOMods);
            this.groupBox1.Controls.Add(this.buttonStartWOTWMods);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(279, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 134);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "World of Tanks";
            // 
            // labelLauncherVersionNumber
            // 
            this.labelLauncherVersionNumber.AutoSize = true;
            this.labelLauncherVersionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLauncherVersionNumber.Location = new System.Drawing.Point(121, 47);
            this.labelLauncherVersionNumber.Name = "labelLauncherVersionNumber";
            this.labelLauncherVersionNumber.Size = new System.Drawing.Size(77, 13);
            this.labelLauncherVersionNumber.TabIndex = 15;
            this.labelLauncherVersionNumber.Text = "no Version info";
            // 
            // labelLauchnerVersion
            // 
            this.labelLauchnerVersion.AutoSize = true;
            this.labelLauchnerVersion.Location = new System.Drawing.Point(10, 47);
            this.labelLauchnerVersion.Name = "labelLauchnerVersion";
            this.labelLauchnerVersion.Size = new System.Drawing.Size(106, 13);
            this.labelLauchnerVersion.TabIndex = 14;
            this.labelLauchnerVersion.Text = "Launcher Version";
            // 
            // labelGameVersionNumber
            // 
            this.labelGameVersionNumber.AutoSize = true;
            this.labelGameVersionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameVersionNumber.Location = new System.Drawing.Point(121, 25);
            this.labelGameVersionNumber.Name = "labelGameVersionNumber";
            this.labelGameVersionNumber.Size = new System.Drawing.Size(77, 13);
            this.labelGameVersionNumber.TabIndex = 13;
            this.labelGameVersionNumber.Text = "no Version info";
            // 
            // labelGameVersion
            // 
            this.labelGameVersion.AutoSize = true;
            this.labelGameVersion.Location = new System.Drawing.Point(10, 25);
            this.labelGameVersion.Name = "labelGameVersion";
            this.labelGameVersion.Size = new System.Drawing.Size(85, 13);
            this.labelGameVersion.TabIndex = 12;
            this.labelGameVersion.Text = "Game Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start WoT";
            // 
            // buttonStartWOTWOMods
            // 
            this.buttonStartWOTWOMods.BackColor = System.Drawing.Color.GreenYellow;
            this.buttonStartWOTWOMods.Location = new System.Drawing.Point(81, 101);
            this.buttonStartWOTWOMods.Name = "buttonStartWOTWOMods";
            this.buttonStartWOTWOMods.Size = new System.Drawing.Size(133, 23);
            this.buttonStartWOTWOMods.TabIndex = 11;
            this.buttonStartWOTWOMods.Text = "without MODs";
            this.buttonStartWOTWOMods.UseVisualStyleBackColor = false;
            // 
            // buttonStartWOTWMods
            // 
            this.buttonStartWOTWMods.BackColor = System.Drawing.Color.LightCoral;
            this.buttonStartWOTWMods.Location = new System.Drawing.Point(81, 72);
            this.buttonStartWOTWMods.Name = "buttonStartWOTWMods";
            this.buttonStartWOTWMods.Size = new System.Drawing.Size(133, 23);
            this.buttonStartWOTWMods.TabIndex = 10;
            this.buttonStartWOTWMods.Text = "with selected Profile";
            this.buttonStartWOTWMods.UseVisualStyleBackColor = false;
            // 
            // buttonProfileNew
            // 
            this.buttonProfileNew.Location = new System.Drawing.Point(360, 11);
            this.buttonProfileNew.Name = "buttonProfileNew";
            this.buttonProfileNew.Size = new System.Drawing.Size(75, 22);
            this.buttonProfileNew.TabIndex = 4;
            this.buttonProfileNew.Text = "new";
            this.buttonProfileNew.UseVisualStyleBackColor = true;
            this.buttonProfileNew.Click += new System.EventHandler(this.buttonProfileNew_Click);
            // 
            // comboBoxProfiles
            // 
            this.comboBoxProfiles.FormattingEnabled = true;
            this.comboBoxProfiles.Location = new System.Drawing.Point(55, 12);
            this.comboBoxProfiles.Name = "comboBoxProfiles";
            this.comboBoxProfiles.Size = new System.Drawing.Size(299, 21);
            this.comboBoxProfiles.Sorted = true;
            this.comboBoxProfiles.TabIndex = 1;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfile.Location = new System.Drawing.Point(6, 14);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(43, 13);
            this.labelProfile.TabIndex = 0;
            this.labelProfile.Text = "Profile";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label8);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(511, 548);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "nope";
            // 
            // tabLog
            // 
            this.tabLog.Controls.Add(this.richTextBoxLog);
            this.tabLog.Location = new System.Drawing.Point(4, 22);
            this.tabLog.Name = "tabLog";
            this.tabLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabLog.Size = new System.Drawing.Size(511, 548);
            this.tabLog.TabIndex = 2;
            this.tabLog.Text = "Log";
            this.tabLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLog.Location = new System.Drawing.Point(6, 6);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ReadOnly = true;
            this.richTextBoxLog.Size = new System.Drawing.Size(499, 539);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Controls.Add(this.label13);
            this.tabAbout.Controls.Add(this.label10);
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Controls.Add(this.label6);
            this.tabAbout.Controls.Add(this.label5);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Controls.Add(this.label2);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(511, 548);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(196, 99);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 20);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Team Klonk!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(230, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "psaiko";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(213, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "developed by";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 519);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "licence GPLv3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "people of the internetz";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "sfm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(184, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Developers + Testers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "WoTModProfileManager";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 599);
            this.Controls.Add(this.tabContainer);
            this.Name = "Form1";
            this.Text = "World of Tanks Mod Profile Manager by Team Klonk!";
            this.tabContainer.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.groupBoxProfileFolder.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.tabLog.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.ComboBox comboBoxProfiles;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonProfileNew;
        private System.Windows.Forms.Button buttonStartWOTWOMods;
        private System.Windows.Forms.Button buttonStartWOTWMods;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Button buttonProfileDelete;
        private System.Windows.Forms.Label labelGameVersionNumber;
        private System.Windows.Forms.Label labelGameVersion;
        private System.Windows.Forms.Label labelLauncherVersionNumber;
        private System.Windows.Forms.Label labelLauchnerVersion;
        private System.Windows.Forms.RichTextBox richTextBoxProfileNotes;
        private System.Windows.Forms.GroupBox groupBoxProfileFolder;
        private System.Windows.Forms.TreeView treeViewProfileFolder;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
    }
}

