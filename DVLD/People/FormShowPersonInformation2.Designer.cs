namespace DVLD
{
    partial class FormShowPersonInformation2
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contolPersonalInformation1 = new DVLD.contolPersonalInformation();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(421, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Information";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contolPersonalInformation1
            // 
            this.contolPersonalInformation1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.contolPersonalInformation1.Location = new System.Drawing.Point(39, 102);
            this.contolPersonalInformation1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.contolPersonalInformation1.Name = "contolPersonalInformation1";
            this.contolPersonalInformation1.Size = new System.Drawing.Size(921, 366);
            this.contolPersonalInformation1.TabIndex = 0;
            // 
            // FormShowPersonInformation2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 543);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.contolPersonalInformation1);
            this.Name = "FormShowPersonInformation2";
            this.Text = "FormShowPersonInformation2";
            this.Load += new System.EventHandler(this.FormShowPersonInformation2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private contolPersonalInformation contolPersonalInformation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}