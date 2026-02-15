namespace DVLD
{
    partial class FormShowLicenseInfo
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
            this.controlLicenseInfo1 = new DVLD.ControlLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlLicenseInfo1
            // 
            this.controlLicenseInfo1.Location = new System.Drawing.Point(30, 67);
            this.controlLicenseInfo1.Name = "controlLicenseInfo1";
            this.controlLicenseInfo1.Size = new System.Drawing.Size(843, 469);
            this.controlLicenseInfo1.TabIndex = 0;
            this.controlLicenseInfo1.Load += new System.EventHandler(this.controlLicenseInfo1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(280, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver License Info";
            // 
            // FormShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 571);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.controlLicenseInfo1);
            this.Name = "FormShowLicenseInfo";
            this.Text = "FormShowLicenseInfo";
            this.Load += new System.EventHandler(this.FormShowLicenseInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlLicenseInfo controlLicenseInfo1;
        private System.Windows.Forms.Label label1;
    }
}