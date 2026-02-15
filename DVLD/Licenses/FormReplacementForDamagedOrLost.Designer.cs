namespace DVLD
{
    partial class FormReplacementForDamagedOrLost
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxReplacement = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAppID = new System.Windows.Forms.Label();
            this.labelAppDate = new System.Windows.Forms.Label();
            this.labelAppFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelReplacedLicenseID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.labelOldLicenseID = new System.Windows.Forms.Label();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.buttonIssue = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.linkLabelShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.linkLabelShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.radioButtonDamaged = new System.Windows.Forms.RadioButton();
            this.radioButtonLost = new System.Windows.Forms.RadioButton();
            this.labeltitle = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBoxReplacement.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlLicenseInfoWithFilter1
            // 
            this.controlLicenseInfoWithFilter1.FilterEnabled = true;
            this.controlLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 48);
            this.controlLicenseInfoWithFilter1.Name = "controlLicenseInfoWithFilter1";
            this.controlLicenseInfoWithFilter1.Size = new System.Drawing.Size(840, 528);
            this.controlLicenseInfoWithFilter1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCreatedBy);
            this.groupBox2.Controls.Add(this.labelOldLicenseID);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelReplacedLicenseID);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelAppFees);
            this.groupBox2.Controls.Add(this.labelAppDate);
            this.groupBox2.Controls.Add(this.labelAppID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(29, 582);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1047, 206);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Info for license Replacement";
            // 
            // groupBoxReplacement
            // 
            this.groupBoxReplacement.Controls.Add(this.radioButtonLost);
            this.groupBoxReplacement.Controls.Add(this.radioButtonDamaged);
            this.groupBoxReplacement.Location = new System.Drawing.Point(858, 60);
            this.groupBoxReplacement.Name = "groupBoxReplacement";
            this.groupBoxReplacement.Size = new System.Drawing.Size(218, 202);
            this.groupBoxReplacement.TabIndex = 3;
            this.groupBoxReplacement.TabStop = false;
            this.groupBoxReplacement.Text = "Replacement for";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "L.R.App ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "App Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "App Fees :";
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Location = new System.Drawing.Point(191, 48);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(45, 19);
            this.labelAppID.TabIndex = 3;
            this.labelAppID.Text = "[???]";
            // 
            // labelAppDate
            // 
            this.labelAppDate.AutoSize = true;
            this.labelAppDate.Location = new System.Drawing.Point(166, 88);
            this.labelAppDate.Name = "labelAppDate";
            this.labelAppDate.Size = new System.Drawing.Size(45, 19);
            this.labelAppDate.TabIndex = 4;
            this.labelAppDate.Text = "[???]";
            // 
            // labelAppFees
            // 
            this.labelAppFees.AutoSize = true;
            this.labelAppFees.Location = new System.Drawing.Point(166, 137);
            this.labelAppFees.Name = "labelAppFees";
            this.labelAppFees.Size = new System.Drawing.Size(45, 19);
            this.labelAppFees.TabIndex = 5;
            this.labelAppFees.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(536, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Replacement License ID :";
            // 
            // labelReplacedLicenseID
            // 
            this.labelReplacedLicenseID.AutoSize = true;
            this.labelReplacedLicenseID.Location = new System.Drawing.Point(762, 48);
            this.labelReplacedLicenseID.Name = "labelReplacedLicenseID";
            this.labelReplacedLicenseID.Size = new System.Drawing.Size(45, 19);
            this.labelReplacedLicenseID.TabIndex = 7;
            this.labelReplacedLicenseID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(536, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "Old License ID :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(536, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 19);
            this.label10.TabIndex = 8;
            this.label10.Text = "Created By :";
            // 
            // labelOldLicenseID
            // 
            this.labelOldLicenseID.AutoSize = true;
            this.labelOldLicenseID.Location = new System.Drawing.Point(753, 88);
            this.labelOldLicenseID.Name = "labelOldLicenseID";
            this.labelOldLicenseID.Size = new System.Drawing.Size(45, 19);
            this.labelOldLicenseID.TabIndex = 9;
            this.labelOldLicenseID.Text = "[???]";
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Location = new System.Drawing.Point(753, 137);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(45, 19);
            this.labelCreatedBy.TabIndex = 10;
            this.labelCreatedBy.Text = "[???]";
            // 
            // buttonIssue
            // 
            this.buttonIssue.Location = new System.Drawing.Point(932, 811);
            this.buttonIssue.Name = "buttonIssue";
            this.buttonIssue.Size = new System.Drawing.Size(123, 38);
            this.buttonIssue.TabIndex = 4;
            this.buttonIssue.Text = "Issue";
            this.buttonIssue.UseVisualStyleBackColor = true;
            this.buttonIssue.Click += new System.EventHandler(this.buttonIssue_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(782, 811);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(123, 38);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // linkLabelShowLicenseInfo
            // 
            this.linkLabelShowLicenseInfo.AutoSize = true;
            this.linkLabelShowLicenseInfo.Location = new System.Drawing.Point(489, 817);
            this.linkLabelShowLicenseInfo.Name = "linkLabelShowLicenseInfo";
            this.linkLabelShowLicenseInfo.Size = new System.Drawing.Size(138, 19);
            this.linkLabelShowLicenseInfo.TabIndex = 6;
            this.linkLabelShowLicenseInfo.TabStop = true;
            this.linkLabelShowLicenseInfo.Text = "Show License Info";
            this.linkLabelShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowLicenseInfo_LinkClicked);
            // 
            // linkLabelShowLicenseHistory
            // 
            this.linkLabelShowLicenseHistory.AutoSize = true;
            this.linkLabelShowLicenseHistory.Location = new System.Drawing.Point(120, 821);
            this.linkLabelShowLicenseHistory.Name = "linkLabelShowLicenseHistory";
            this.linkLabelShowLicenseHistory.Size = new System.Drawing.Size(159, 19);
            this.linkLabelShowLicenseHistory.TabIndex = 7;
            this.linkLabelShowLicenseHistory.TabStop = true;
            this.linkLabelShowLicenseHistory.Text = "Show License History";
            // 
            // radioButtonDamaged
            // 
            this.radioButtonDamaged.AutoSize = true;
            this.radioButtonDamaged.Location = new System.Drawing.Point(40, 59);
            this.radioButtonDamaged.Name = "radioButtonDamaged";
            this.radioButtonDamaged.Size = new System.Drawing.Size(157, 23);
            this.radioButtonDamaged.TabIndex = 0;
            this.radioButtonDamaged.TabStop = true;
            this.radioButtonDamaged.Text = "Damaged License";
            this.radioButtonDamaged.UseVisualStyleBackColor = true;
            this.radioButtonDamaged.CheckedChanged += new System.EventHandler(this.radioButtonDamaged_CheckedChanged);
            // 
            // radioButtonLost
            // 
            this.radioButtonLost.AutoSize = true;
            this.radioButtonLost.Location = new System.Drawing.Point(40, 133);
            this.radioButtonLost.Name = "radioButtonLost";
            this.radioButtonLost.Size = new System.Drawing.Size(119, 23);
            this.radioButtonLost.TabIndex = 1;
            this.radioButtonLost.TabStop = true;
            this.radioButtonLost.Text = "Lost License";
            this.radioButtonLost.UseVisualStyleBackColor = true;
            this.radioButtonLost.CheckedChanged += new System.EventHandler(this.radioButtonLost_CheckedChanged);
            // 
            // labeltitle
            // 
            this.labeltitle.AutoSize = true;
            this.labeltitle.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labeltitle.ForeColor = System.Drawing.Color.Red;
            this.labeltitle.Location = new System.Drawing.Point(332, 9);
            this.labeltitle.Name = "labeltitle";
            this.labeltitle.Size = new System.Drawing.Size(421, 31);
            this.labeltitle.TabIndex = 8;
            this.labeltitle.Text = "Replacement For Damaged Liecnse";
            // 
            // FormReplacementForDamagedOrLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 861);
            this.Controls.Add(this.labeltitle);
            this.Controls.Add(this.linkLabelShowLicenseHistory);
            this.Controls.Add(this.linkLabelShowLicenseInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonIssue);
            this.Controls.Add(this.groupBoxReplacement);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.controlLicenseInfoWithFilter1);
            this.Name = "FormReplacementForDamagedOrLost";
            this.Text = "FormReplacementForDamagedOrLost";
            this.Load += new System.EventHandler(this.FormReplacementForDamagedOrLost_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxReplacement.ResumeLayout(false);
            this.groupBoxReplacement.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLicenseInfoWithFilter controlLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.Label labelOldLicenseID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelReplacedLicenseID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelAppFees;
        private System.Windows.Forms.Label labelAppDate;
        private System.Windows.Forms.Label labelAppID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxReplacement;
        private System.Windows.Forms.RadioButton radioButtonLost;
        private System.Windows.Forms.RadioButton radioButtonDamaged;
        private System.Windows.Forms.Button buttonIssue;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelShowLicenseHistory;
        private System.Windows.Forms.Label labeltitle;
    }
}