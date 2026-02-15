namespace DVLD
{
    partial class FormFindPerson
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
            this.controlPersonalInformationWithFilter1 = new DVLD.ControlPersonalInformationWithFilter();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // controlPersonalInformationWithFilter1
            // 
            this.controlPersonalInformationWithFilter1.FilterEnabled = true;
            this.controlPersonalInformationWithFilter1.Location = new System.Drawing.Point(25, 94);
            this.controlPersonalInformationWithFilter1.Name = "controlPersonalInformationWithFilter1";
            this.controlPersonalInformationWithFilter1.ShowAddNewPerson = true;
            this.controlPersonalInformationWithFilter1.Size = new System.Drawing.Size(987, 494);
            this.controlPersonalInformationWithFilter1.TabIndex = 0;
            this.controlPersonalInformationWithFilter1.Load += new System.EventHandler(this.controlPersonalInformationWithFilter1_Load);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(810, 631);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(154, 47);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(433, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find Person";
            // 
            // FormFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1061, 690);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.controlPersonalInformationWithFilter1);
            this.Name = "FormFindPerson";
            this.Text = "FormFindPerson";
            this.Load += new System.EventHandler(this.FormFindPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlPersonalInformationWithFilter controlPersonalInformationWithFilter1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
    }
}