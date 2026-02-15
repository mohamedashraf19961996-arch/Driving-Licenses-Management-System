namespace DVLD
{
    partial class ControlLocalDriverLicenseInformation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelType = new System.Windows.Forms.Label();
            this.labelLDID = new System.Windows.Forms.Label();
            this.labelPassedTest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.controlAppInformation1 = new DVLD.ControlAppInformation();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelType);
            this.groupBox1.Controls.Add(this.labelLDID);
            this.groupBox1.Controls.Add(this.labelPassedTest);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local Driver License Info";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(104, 98);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(45, 19);
            this.labelType.TabIndex = 5;
            this.labelType.Text = "[???]";
            // 
            // labelLDID
            // 
            this.labelLDID.AutoSize = true;
            this.labelLDID.Location = new System.Drawing.Point(143, 46);
            this.labelLDID.Name = "labelLDID";
            this.labelLDID.Size = new System.Drawing.Size(45, 19);
            this.labelLDID.TabIndex = 4;
            this.labelLDID.Text = "[???]";
            this.labelLDID.Click += new System.EventHandler(this.label5_Click);
            // 
            // labelPassedTest
            // 
            this.labelPassedTest.AutoSize = true;
            this.labelPassedTest.Location = new System.Drawing.Point(507, 46);
            this.labelPassedTest.Name = "labelPassedTest";
            this.labelPassedTest.Size = new System.Drawing.Size(45, 19);
            this.labelPassedTest.TabIndex = 3;
            this.labelPassedTest.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Passed Test :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "D.L.App ID :";
            // 
            // controlAppInformation1
            // 
            this.controlAppInformation1.Location = new System.Drawing.Point(3, 165);
            this.controlAppInformation1.Name = "controlAppInformation1";
            this.controlAppInformation1.Size = new System.Drawing.Size(774, 327);
            this.controlAppInformation1.TabIndex = 0;
            this.controlAppInformation1.Load += new System.EventHandler(this.controlAppInformation1_Load);
            // 
            // ControlLocalDriverLicenseInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlAppInformation1);
            this.Name = "ControlLocalDriverLicenseInformation";
            this.Size = new System.Drawing.Size(786, 495);
            this.Load += new System.EventHandler(this.ControlLocalDriverLicenseInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlAppInformation controlAppInformation1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelLDID;
        private System.Windows.Forms.Label labelPassedTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelType;
    }
}
