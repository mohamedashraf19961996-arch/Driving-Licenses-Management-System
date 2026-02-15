namespace DVLD
{
    partial class FormUserInfo
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
            this.controlUserInformation1 = new DVLD.ControlUserInformation();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // controlUserInformation1
            // 
            this.controlUserInformation1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.controlUserInformation1.Location = new System.Drawing.Point(27, 32);
            this.controlUserInformation1.Name = "controlUserInformation1";
            this.controlUserInformation1.Size = new System.Drawing.Size(922, 370);
            this.controlUserInformation1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(730, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 467);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.controlUserInformation1);
            this.Name = "FormUserInfo";
            this.Text = "FormUserInfo";
            this.Load += new System.EventHandler(this.FormUserInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUserInformation controlUserInformation1;
        private System.Windows.Forms.Button button1;
    }
}