namespace DVLD
{
    partial class FormReleaseDetainLicense
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
            this.controlLicenseInfoWithFilter1 = new DVLD.ControlLicenseInfoWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabelLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelLicenseID = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.labelFineFees = new System.Windows.Forms.Label();
            this.labelAppID = new System.Windows.Forms.Label();
            this.labelDetainID = new System.Windows.Forms.Label();
            this.labelDetainDate = new System.Windows.Forms.Label();
            this.labelAppFees = new System.Windows.Forms.Label();
            this.labelTotalFees = new System.Windows.Forms.Label();
            this.labelRelease = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlLicenseInfoWithFilter1
            // 
            this.controlLicenseInfoWithFilter1.FilterEnabled = true;
            this.controlLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 55);
            this.controlLicenseInfoWithFilter1.Name = "controlLicenseInfoWithFilter1";
            this.controlLicenseInfoWithFilter1.Size = new System.Drawing.Size(840, 528);
            this.controlLicenseInfoWithFilter1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTotalFees);
            this.groupBox1.Controls.Add(this.labelAppFees);
            this.groupBox1.Controls.Add(this.labelDetainDate);
            this.groupBox1.Controls.Add(this.labelDetainID);
            this.groupBox1.Controls.Add(this.labelAppID);
            this.groupBox1.Controls.Add(this.labelFineFees);
            this.groupBox1.Controls.Add(this.labelUserID);
            this.groupBox1.Controls.Add(this.labelLicenseID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(25, 577);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(720, 816);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(134, 41);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Release";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(569, 816);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(134, 41);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // linkLabelLicenseInfo
            // 
            this.linkLabelLicenseInfo.AutoSize = true;
            this.linkLabelLicenseInfo.Location = new System.Drawing.Point(299, 838);
            this.linkLabelLicenseInfo.Name = "linkLabelLicenseInfo";
            this.linkLabelLicenseInfo.Size = new System.Drawing.Size(138, 19);
            this.linkLabelLicenseInfo.TabIndex = 4;
            this.linkLabelLicenseInfo.TabStop = true;
            this.linkLabelLicenseInfo.Text = "Show License Info";
            this.linkLabelLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseInfo_LinkClicked);
            // 
            // linkLabelLicenseHistory
            // 
            this.linkLabelLicenseHistory.AutoSize = true;
            this.linkLabelLicenseHistory.Location = new System.Drawing.Point(49, 838);
            this.linkLabelLicenseHistory.Name = "linkLabelLicenseHistory";
            this.linkLabelLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.linkLabelLicenseHistory.TabIndex = 5;
            this.linkLabelLicenseHistory.TabStop = true;
            this.linkLabelLicenseHistory.Text = "Show License History";
            this.linkLabelLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLicenseHistory_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detain Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "App Fees :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Fees :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "License Id :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(422, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Created  By :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fine Fees :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "Application ID :";
            // 
            // labelLicenseID
            // 
            this.labelLicenseID.AutoSize = true;
            this.labelLicenseID.Location = new System.Drawing.Point(540, 35);
            this.labelLicenseID.Name = "labelLicenseID";
            this.labelLicenseID.Size = new System.Drawing.Size(45, 19);
            this.labelLicenseID.TabIndex = 8;
            this.labelLicenseID.Text = "[???]";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(540, 77);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(45, 19);
            this.labelUserID.TabIndex = 9;
            this.labelUserID.Text = "[???]";
            // 
            // labelFineFees
            // 
            this.labelFineFees.AutoSize = true;
            this.labelFineFees.Location = new System.Drawing.Point(540, 118);
            this.labelFineFees.Name = "labelFineFees";
            this.labelFineFees.Size = new System.Drawing.Size(45, 19);
            this.labelFineFees.TabIndex = 10;
            this.labelFineFees.Text = "[???]";
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Location = new System.Drawing.Point(540, 162);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(45, 19);
            this.labelAppID.TabIndex = 11;
            this.labelAppID.Text = "[???]";
            // 
            // labelDetainID
            // 
            this.labelDetainID.AutoSize = true;
            this.labelDetainID.Location = new System.Drawing.Point(134, 35);
            this.labelDetainID.Name = "labelDetainID";
            this.labelDetainID.Size = new System.Drawing.Size(45, 19);
            this.labelDetainID.TabIndex = 12;
            this.labelDetainID.Text = "[???]";
            // 
            // labelDetainDate
            // 
            this.labelDetainDate.AutoSize = true;
            this.labelDetainDate.Location = new System.Drawing.Point(134, 77);
            this.labelDetainDate.Name = "labelDetainDate";
            this.labelDetainDate.Size = new System.Drawing.Size(45, 19);
            this.labelDetainDate.TabIndex = 13;
            this.labelDetainDate.Text = "[???]";
            // 
            // labelAppFees
            // 
            this.labelAppFees.AutoSize = true;
            this.labelAppFees.Location = new System.Drawing.Point(134, 118);
            this.labelAppFees.Name = "labelAppFees";
            this.labelAppFees.Size = new System.Drawing.Size(45, 19);
            this.labelAppFees.TabIndex = 14;
            this.labelAppFees.Text = "[???]";
            // 
            // labelTotalFees
            // 
            this.labelTotalFees.AutoSize = true;
            this.labelTotalFees.Location = new System.Drawing.Point(134, 162);
            this.labelTotalFees.Name = "labelTotalFees";
            this.labelTotalFees.Size = new System.Drawing.Size(45, 19);
            this.labelTotalFees.TabIndex = 15;
            this.labelTotalFees.Text = "[???]";
            // 
            // labelRelease
            // 
            this.labelRelease.AutoSize = true;
            this.labelRelease.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelRelease.ForeColor = System.Drawing.Color.Red;
            this.labelRelease.Location = new System.Drawing.Point(361, 19);
            this.labelRelease.Name = "labelRelease";
            this.labelRelease.Size = new System.Drawing.Size(198, 31);
            this.labelRelease.TabIndex = 6;
            this.labelRelease.Text = "Release License";
            // 
            // FormReleaseDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 910);
            this.Controls.Add(this.labelRelease);
            this.Controls.Add(this.linkLabelLicenseHistory);
            this.Controls.Add(this.linkLabelLicenseInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlLicenseInfoWithFilter1);
            this.Name = "FormReleaseDetainLicense";
            this.Text = "FormReleaseDetainLicense";
            this.Load += new System.EventHandler(this.FormReleaseDetainLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLicenseInfoWithFilter controlLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTotalFees;
        private System.Windows.Forms.Label labelAppFees;
        private System.Windows.Forms.Label labelDetainDate;
        private System.Windows.Forms.Label labelDetainID;
        private System.Windows.Forms.Label labelAppID;
        private System.Windows.Forms.Label labelFineFees;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label labelLicenseID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelLicenseHistory;
        private System.Windows.Forms.Label labelRelease;
    }
}