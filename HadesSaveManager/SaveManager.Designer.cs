namespace HadesSaveManager
{
    partial class SaveManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboxSelectProfile = new System.Windows.Forms.GroupBox();
            this.radioProfile4 = new System.Windows.Forms.RadioButton();
            this.radioProfile3 = new System.Windows.Forms.RadioButton();
            this.radioProfile2 = new System.Windows.Forms.RadioButton();
            this.radioProfile1 = new System.Windows.Forms.RadioButton();
            this.lblSaveFolder = new System.Windows.Forms.Label();
            this.linkChangeSavePath = new System.Windows.Forms.LinkLabel();
            this.lblSaveFolderPath = new System.Windows.Forms.Label();
            this.lblRouteFolder = new System.Windows.Forms.Label();
            this.lblRouteFolderPath = new System.Windows.Forms.Label();
            this.linkChangeRoutePath = new System.Windows.Forms.LinkLabel();
            this.btnCreateSnapshot = new System.Windows.Forms.Button();
            this.txtNewSnapshot = new System.Windows.Forms.TextBox();
            this.gboxNewSnapshot = new System.Windows.Forms.GroupBox();
            this.lblNewSnapshot = new System.Windows.Forms.Label();
            this.lblLoadSnapshot = new System.Windows.Forms.Label();
            this.btnLoadSnapshot = new System.Windows.Forms.Button();
            this.gboxLoadSnapshot = new System.Windows.Forms.GroupBox();
            this.btnDeleteSnapshot = new System.Windows.Forms.Button();
            this.cboxLoadSnapshot = new System.Windows.Forms.ComboBox();
            this.linkOpenSaveFolder = new System.Windows.Forms.LinkLabel();
            this.linkOpenRouteFolder = new System.Windows.Forms.LinkLabel();
            this.gboxSelectProfile.SuspendLayout();
            this.gboxNewSnapshot.SuspendLayout();
            this.gboxLoadSnapshot.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxSelectProfile
            // 
            this.gboxSelectProfile.Controls.Add(this.radioProfile4);
            this.gboxSelectProfile.Controls.Add(this.radioProfile3);
            this.gboxSelectProfile.Controls.Add(this.radioProfile2);
            this.gboxSelectProfile.Controls.Add(this.radioProfile1);
            this.gboxSelectProfile.Location = new System.Drawing.Point(12, 12);
            this.gboxSelectProfile.Name = "gboxSelectProfile";
            this.gboxSelectProfile.Size = new System.Drawing.Size(299, 53);
            this.gboxSelectProfile.TabIndex = 0;
            this.gboxSelectProfile.TabStop = false;
            this.gboxSelectProfile.Text = "Select Profile";
            // 
            // radioProfile4
            // 
            this.radioProfile4.AutoSize = true;
            this.radioProfile4.Location = new System.Drawing.Point(228, 22);
            this.radioProfile4.Name = "radioProfile4";
            this.radioProfile4.Size = new System.Drawing.Size(68, 19);
            this.radioProfile4.TabIndex = 0;
            this.radioProfile4.TabStop = true;
            this.radioProfile4.Tag = "4";
            this.radioProfile4.Text = "Profile 4";
            this.radioProfile4.UseVisualStyleBackColor = true;
            this.radioProfile4.CheckedChanged += new System.EventHandler(this.RadioProfile_CheckedChanged);
            // 
            // radioProfile3
            // 
            this.radioProfile3.AutoSize = true;
            this.radioProfile3.Location = new System.Drawing.Point(154, 22);
            this.radioProfile3.Name = "radioProfile3";
            this.radioProfile3.Size = new System.Drawing.Size(68, 19);
            this.radioProfile3.TabIndex = 0;
            this.radioProfile3.TabStop = true;
            this.radioProfile3.Tag = "3";
            this.radioProfile3.Text = "Profile 3";
            this.radioProfile3.UseVisualStyleBackColor = true;
            this.radioProfile3.CheckedChanged += new System.EventHandler(this.RadioProfile_CheckedChanged);
            // 
            // radioProfile2
            // 
            this.radioProfile2.AutoSize = true;
            this.radioProfile2.Location = new System.Drawing.Point(80, 22);
            this.radioProfile2.Name = "radioProfile2";
            this.radioProfile2.Size = new System.Drawing.Size(68, 19);
            this.radioProfile2.TabIndex = 0;
            this.radioProfile2.TabStop = true;
            this.radioProfile2.Tag = "2";
            this.radioProfile2.Text = "Profile 2";
            this.radioProfile2.UseVisualStyleBackColor = true;
            this.radioProfile2.CheckedChanged += new System.EventHandler(this.RadioProfile_CheckedChanged);
            // 
            // radioProfile1
            // 
            this.radioProfile1.AutoSize = true;
            this.radioProfile1.Location = new System.Drawing.Point(6, 22);
            this.radioProfile1.Name = "radioProfile1";
            this.radioProfile1.Size = new System.Drawing.Size(68, 19);
            this.radioProfile1.TabIndex = 0;
            this.radioProfile1.TabStop = true;
            this.radioProfile1.Tag = "1";
            this.radioProfile1.Text = "Profile 1";
            this.radioProfile1.UseVisualStyleBackColor = true;
            this.radioProfile1.CheckedChanged += new System.EventHandler(this.RadioProfile_CheckedChanged);
            // 
            // lblSaveFolder
            // 
            this.lblSaveFolder.AutoSize = true;
            this.lblSaveFolder.Location = new System.Drawing.Point(12, 78);
            this.lblSaveFolder.Name = "lblSaveFolder";
            this.lblSaveFolder.Size = new System.Drawing.Size(103, 15);
            this.lblSaveFolder.TabIndex = 1;
            this.lblSaveFolder.Text = "Hades Save Folder";
            // 
            // linkChangeSavePath
            // 
            this.linkChangeSavePath.AutoSize = true;
            this.linkChangeSavePath.Location = new System.Drawing.Point(121, 78);
            this.linkChangeSavePath.Name = "linkChangeSavePath";
            this.linkChangeSavePath.Size = new System.Drawing.Size(56, 15);
            this.linkChangeSavePath.TabIndex = 2;
            this.linkChangeSavePath.TabStop = true;
            this.linkChangeSavePath.Text = "(Change)";
            this.linkChangeSavePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkChangePath_LinkClicked);
            // 
            // lblSaveFolderPath
            // 
            this.lblSaveFolderPath.AutoSize = true;
            this.lblSaveFolderPath.Location = new System.Drawing.Point(12, 102);
            this.lblSaveFolderPath.Name = "lblSaveFolderPath";
            this.lblSaveFolderPath.Size = new System.Drawing.Size(113, 15);
            this.lblSaveFolderPath.TabIndex = 3;
            this.lblSaveFolderPath.Text = "<No Path Selected>";
            // 
            // lblRouteFolder
            // 
            this.lblRouteFolder.AutoSize = true;
            this.lblRouteFolder.Location = new System.Drawing.Point(12, 139);
            this.lblRouteFolder.Name = "lblRouteFolder";
            this.lblRouteFolder.Size = new System.Drawing.Size(74, 15);
            this.lblRouteFolder.TabIndex = 1;
            this.lblRouteFolder.Text = "Route Folder";
            // 
            // lblRouteFolderPath
            // 
            this.lblRouteFolderPath.AutoSize = true;
            this.lblRouteFolderPath.Location = new System.Drawing.Point(12, 163);
            this.lblRouteFolderPath.Name = "lblRouteFolderPath";
            this.lblRouteFolderPath.Size = new System.Drawing.Size(113, 15);
            this.lblRouteFolderPath.TabIndex = 3;
            this.lblRouteFolderPath.Text = "<No Path Selected>";
            // 
            // linkChangeRoutePath
            // 
            this.linkChangeRoutePath.AutoSize = true;
            this.linkChangeRoutePath.Location = new System.Drawing.Point(92, 139);
            this.linkChangeRoutePath.Name = "linkChangeRoutePath";
            this.linkChangeRoutePath.Size = new System.Drawing.Size(56, 15);
            this.linkChangeRoutePath.TabIndex = 2;
            this.linkChangeRoutePath.TabStop = true;
            this.linkChangeRoutePath.Text = "(Change)";
            this.linkChangeRoutePath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkChangePath_LinkClicked);
            // 
            // btnCreateSnapshot
            // 
            this.btnCreateSnapshot.Location = new System.Drawing.Point(100, 66);
            this.btnCreateSnapshot.Name = "btnCreateSnapshot";
            this.btnCreateSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnCreateSnapshot.TabIndex = 4;
            this.btnCreateSnapshot.Text = "Create";
            this.btnCreateSnapshot.UseVisualStyleBackColor = true;
            this.btnCreateSnapshot.Click += new System.EventHandler(this.BtnCreateSnapshot_Click);
            // 
            // txtNewSnapshot
            // 
            this.txtNewSnapshot.Location = new System.Drawing.Point(6, 37);
            this.txtNewSnapshot.Name = "txtNewSnapshot";
            this.txtNewSnapshot.Size = new System.Drawing.Size(287, 23);
            this.txtNewSnapshot.TabIndex = 6;
            // 
            // gboxNewSnapshot
            // 
            this.gboxNewSnapshot.Controls.Add(this.lblNewSnapshot);
            this.gboxNewSnapshot.Controls.Add(this.txtNewSnapshot);
            this.gboxNewSnapshot.Controls.Add(this.btnCreateSnapshot);
            this.gboxNewSnapshot.Location = new System.Drawing.Point(12, 200);
            this.gboxNewSnapshot.Name = "gboxNewSnapshot";
            this.gboxNewSnapshot.Size = new System.Drawing.Size(299, 100);
            this.gboxNewSnapshot.TabIndex = 7;
            this.gboxNewSnapshot.TabStop = false;
            this.gboxNewSnapshot.Text = "New Snapshot";
            // 
            // lblNewSnapshot
            // 
            this.lblNewSnapshot.AutoSize = true;
            this.lblNewSnapshot.Location = new System.Drawing.Point(100, 19);
            this.lblNewSnapshot.Name = "lblNewSnapshot";
            this.lblNewSnapshot.Size = new System.Drawing.Size(91, 15);
            this.lblNewSnapshot.TabIndex = 7;
            this.lblNewSnapshot.Text = "Snapshot Name";
            // 
            // lblLoadSnapshot
            // 
            this.lblLoadSnapshot.AutoSize = true;
            this.lblLoadSnapshot.Location = new System.Drawing.Point(89, 19);
            this.lblLoadSnapshot.Name = "lblLoadSnapshot";
            this.lblLoadSnapshot.Size = new System.Drawing.Size(108, 15);
            this.lblLoadSnapshot.TabIndex = 7;
            this.lblLoadSnapshot.Text = "Choose a Snapshot";
            // 
            // btnLoadSnapshot
            // 
            this.btnLoadSnapshot.Location = new System.Drawing.Point(39, 66);
            this.btnLoadSnapshot.Name = "btnLoadSnapshot";
            this.btnLoadSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnLoadSnapshot.TabIndex = 4;
            this.btnLoadSnapshot.Text = "Load";
            this.btnLoadSnapshot.UseVisualStyleBackColor = true;
            this.btnLoadSnapshot.Click += new System.EventHandler(this.BtnLoadSnapshot_Click);
            // 
            // gboxLoadSnapshot
            // 
            this.gboxLoadSnapshot.Controls.Add(this.btnDeleteSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.cboxLoadSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.lblLoadSnapshot);
            this.gboxLoadSnapshot.Controls.Add(this.btnLoadSnapshot);
            this.gboxLoadSnapshot.Location = new System.Drawing.Point(12, 319);
            this.gboxLoadSnapshot.Name = "gboxLoadSnapshot";
            this.gboxLoadSnapshot.Size = new System.Drawing.Size(299, 100);
            this.gboxLoadSnapshot.TabIndex = 7;
            this.gboxLoadSnapshot.TabStop = false;
            this.gboxLoadSnapshot.Text = "Manage Snapshots";
            // 
            // btnDeleteSnapshot
            // 
            this.btnDeleteSnapshot.Location = new System.Drawing.Point(154, 66);
            this.btnDeleteSnapshot.Name = "btnDeleteSnapshot";
            this.btnDeleteSnapshot.Size = new System.Drawing.Size(97, 23);
            this.btnDeleteSnapshot.TabIndex = 4;
            this.btnDeleteSnapshot.Text = "Delete";
            this.btnDeleteSnapshot.UseVisualStyleBackColor = true;
            this.btnDeleteSnapshot.Click += new System.EventHandler(this.BtnDeleteSnapshot_Click);
            // 
            // cboxLoadSnapshot
            // 
            this.cboxLoadSnapshot.FormattingEnabled = true;
            this.cboxLoadSnapshot.Location = new System.Drawing.Point(6, 37);
            this.cboxLoadSnapshot.Name = "cboxLoadSnapshot";
            this.cboxLoadSnapshot.Size = new System.Drawing.Size(287, 23);
            this.cboxLoadSnapshot.TabIndex = 8;
            this.cboxLoadSnapshot.Click += new System.EventHandler(this.CboxLoadSnapshot_Click);
            // 
            // linkOpenSaveFolder
            // 
            this.linkOpenSaveFolder.AutoSize = true;
            this.linkOpenSaveFolder.Location = new System.Drawing.Point(183, 78);
            this.linkOpenSaveFolder.Name = "linkOpenSaveFolder";
            this.linkOpenSaveFolder.Size = new System.Drawing.Size(44, 15);
            this.linkOpenSaveFolder.TabIndex = 2;
            this.linkOpenSaveFolder.TabStop = true;
            this.linkOpenSaveFolder.Text = "(Open)";
            this.linkOpenSaveFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOpenFolder_LinkClicked);
            // 
            // linkOpenRouteFolder
            // 
            this.linkOpenRouteFolder.AutoSize = true;
            this.linkOpenRouteFolder.Location = new System.Drawing.Point(154, 139);
            this.linkOpenRouteFolder.Name = "linkOpenRouteFolder";
            this.linkOpenRouteFolder.Size = new System.Drawing.Size(44, 15);
            this.linkOpenRouteFolder.TabIndex = 2;
            this.linkOpenRouteFolder.TabStop = true;
            this.linkOpenRouteFolder.Text = "(Open)";
            this.linkOpenRouteFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkOpenFolder_LinkClicked);
            // 
            // SaveManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 429);
            this.Controls.Add(this.linkOpenRouteFolder);
            this.Controls.Add(this.linkOpenSaveFolder);
            this.Controls.Add(this.gboxLoadSnapshot);
            this.Controls.Add(this.gboxNewSnapshot);
            this.Controls.Add(this.linkChangeRoutePath);
            this.Controls.Add(this.lblRouteFolderPath);
            this.Controls.Add(this.lblRouteFolder);
            this.Controls.Add(this.lblSaveFolderPath);
            this.Controls.Add(this.linkChangeSavePath);
            this.Controls.Add(this.lblSaveFolder);
            this.Controls.Add(this.gboxSelectProfile);
            this.Name = "SaveManager";
            this.Text = "Hades Save Manager";
            this.gboxSelectProfile.ResumeLayout(false);
            this.gboxSelectProfile.PerformLayout();
            this.gboxNewSnapshot.ResumeLayout(false);
            this.gboxNewSnapshot.PerformLayout();
            this.gboxLoadSnapshot.ResumeLayout(false);
            this.gboxLoadSnapshot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxSelectProfile;
        private System.Windows.Forms.RadioButton radioProfile4;
        private System.Windows.Forms.RadioButton radioProfile3;
        private System.Windows.Forms.RadioButton radioProfile2;
        private System.Windows.Forms.RadioButton radioProfile1;
        private System.Windows.Forms.Label lblSaveFolder;
        private System.Windows.Forms.LinkLabel linkChangeSavePath;
        private System.Windows.Forms.Label lblSaveFolderPath;
        private System.Windows.Forms.Label lblRouteFolder;
        private System.Windows.Forms.Label lblRouteFolderPath;
        private System.Windows.Forms.LinkLabel linkChangeRoutePath;
        private System.Windows.Forms.Button btnCreateSnapshot;
        private System.Windows.Forms.TextBox txtNewSnapshot;
        private System.Windows.Forms.GroupBox gboxNewSnapshot;
        private System.Windows.Forms.Label lblNewSnapshot;
        private System.Windows.Forms.Label lblLoadSnapshot;
        private System.Windows.Forms.Button btnLoadSnapshot;
        private System.Windows.Forms.GroupBox gboxLoadSnapshot;
        private System.Windows.Forms.ComboBox cboxLoadSnapshot;
        private System.Windows.Forms.LinkLabel linkOpenSaveFolder;
        private System.Windows.Forms.LinkLabel linkOpenRouteFolder;
        private System.Windows.Forms.Button btnDeleteSnapshot;
    }
}

