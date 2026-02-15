namespace DVLD
{
    partial class FormLocalLicenseInformation
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
            this.button1 = new System.Windows.Forms.Button();
            this.controlLocalDriverLicenseInformation1 = new DVLD.ControlLocalDriverLicenseInformation();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controlLocalDriverLicenseInformation1
            // 
            this.controlLocalDriverLicenseInformation1.Location = new System.Drawing.Point(68, 12);
            this.controlLocalDriverLicenseInformation1.Name = "controlLocalDriverLicenseInformation1";
            this.controlLocalDriverLicenseInformation1.Size = new System.Drawing.Size(786, 495);
            this.controlLocalDriverLicenseInformation1.TabIndex = 1;
            // 
            // FormLocalLicenseInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 564);
            this.Controls.Add(this.controlLocalDriverLicenseInformation1);
            this.Controls.Add(this.button1);
            this.Name = "FormLocalLicenseInformation";
            this.Text = "FormLocalLicenseInformation";
            this.Load += new System.EventHandler(this.FormLocalLicenseInformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ControlLocalDriverLicenseInformation controlLocalDriverLicenseInformation1;
    }
}