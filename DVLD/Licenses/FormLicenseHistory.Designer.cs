namespace DVLD
{
    partial class FormLicenseHistory
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
            this.controlLicenseHistoryInfo1 = new DVLD.controlLicenseHistoryInfo();
            this.SuspendLayout();
            // 
            // controlLicenseHistoryInfo1
            // 
            this.controlLicenseHistoryInfo1.Location = new System.Drawing.Point(12, 12);
            this.controlLicenseHistoryInfo1.Name = "controlLicenseHistoryInfo1";
            this.controlLicenseHistoryInfo1.Size = new System.Drawing.Size(974, 751);
            this.controlLicenseHistoryInfo1.TabIndex = 0;
            this.controlLicenseHistoryInfo1.Load += new System.EventHandler(this.controlLicenseHistoryInfo1_Load);
            // 
            // FormLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 760);
            this.Controls.Add(this.controlLicenseHistoryInfo1);
            this.Name = "FormLicenseHistory";
            this.Text = "FormLicenseHistory";
            this.Load += new System.EventHandler(this.FormLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private controlLicenseHistoryInfo controlLicenseHistoryInfo1;
    }
}