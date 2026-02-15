namespace DVLD
{
    partial class FormDetainLicenses
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
            this.labelLicenseID = new System.Windows.Forms.Label();
            this.labelCreatedBy = new System.Windows.Forms.Label();
            this.labelDetainID = new System.Windows.Forms.Label();
            this.labelDetainDate = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.controlLicenseInfoWithFilter1 = new DVLD.ControlLicenseInfoWithFilter();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.labelDetainDate);
            this.groupBox1.Controls.Add(this.labelDetainID);
            this.groupBox1.Controls.Add(this.labelCreatedBy);
            this.groupBox1.Controls.Add(this.labelLicenseID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(30, 592);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(822, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(725, 791);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 42);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Detain";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(578, 791);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(126, 42);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // linkLabelLicenseInfo
            // 
            this.linkLabelLicenseInfo.AutoSize = true;
            this.linkLabelLicenseInfo.Location = new System.Drawing.Point(313, 814);
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
            this.linkLabelLicenseHistory.Location = new System.Drawing.Point(75, 814);
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
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Detain Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fine Fees :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "License ID :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(469, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Created By :";
            // 
            // labelLicenseID
            // 
            this.labelLicenseID.AutoSize = true;
            this.labelLicenseID.Location = new System.Drawing.Point(573, 45);
            this.labelLicenseID.Name = "labelLicenseID";
            this.labelLicenseID.Size = new System.Drawing.Size(45, 19);
            this.labelLicenseID.TabIndex = 5;
            this.labelLicenseID.Text = "[???]";
            // 
            // labelCreatedBy
            // 
            this.labelCreatedBy.AutoSize = true;
            this.labelCreatedBy.Location = new System.Drawing.Point(573, 94);
            this.labelCreatedBy.Name = "labelCreatedBy";
            this.labelCreatedBy.Size = new System.Drawing.Size(45, 19);
            this.labelCreatedBy.TabIndex = 6;
            this.labelCreatedBy.Text = "[???]";
            // 
            // labelDetainID
            // 
            this.labelDetainID.AutoSize = true;
            this.labelDetainID.Location = new System.Drawing.Point(141, 42);
            this.labelDetainID.Name = "labelDetainID";
            this.labelDetainID.Size = new System.Drawing.Size(45, 19);
            this.labelDetainID.TabIndex = 7;
            this.labelDetainID.Text = "[???]";
            // 
            // labelDetainDate
            // 
            this.labelDetainDate.AutoSize = true;
            this.labelDetainDate.Location = new System.Drawing.Point(164, 82);
            this.labelDetainDate.Name = "labelDetainDate";
            this.labelDetainDate.Size = new System.Drawing.Size(45, 19);
            this.labelDetainDate.TabIndex = 8;
            this.labelDetainDate.Text = "[???]";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 27);
            this.textBox1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(336, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 29);
            this.label6.TabIndex = 6;
            this.label6.Text = "Detain License";
            // 
            // controlLicenseInfoWithFilter1
            // 
            this.controlLicenseInfoWithFilter1.FilterEnabled = true;
            this.controlLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 58);
            this.controlLicenseInfoWithFilter1.Name = "controlLicenseInfoWithFilter1";
            this.controlLicenseInfoWithFilter1.Size = new System.Drawing.Size(840, 528);
            this.controlLicenseInfoWithFilter1.TabIndex = 0;
            // 
            // FormDetainLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 850);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabelLicenseHistory);
            this.Controls.Add(this.linkLabelLicenseInfo);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlLicenseInfoWithFilter1);
            this.Name = "FormDetainLicenses";
            this.Text = "FormDetainLicenses";
            this.Load += new System.EventHandler(this.FormDetainLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLicenseInfoWithFilter controlLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.LinkLabel linkLabelLicenseInfo;
        private System.Windows.Forms.LinkLabel linkLabelLicenseHistory;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelDetainDate;
        private System.Windows.Forms.Label labelDetainID;
        private System.Windows.Forms.Label labelCreatedBy;
        private System.Windows.Forms.Label labelLicenseID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}