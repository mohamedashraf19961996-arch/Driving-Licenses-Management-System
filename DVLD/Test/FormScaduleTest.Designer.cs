namespace DVLD
{
    partial class FormScaduleTest
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
            this.controlScadualeTest1 = new DVLD.ControlScadualeTest();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // controlScadualeTest1
            // 
            this.controlScadualeTest1.Location = new System.Drawing.Point(12, 12);
            this.controlScadualeTest1.Name = "controlScadualeTest1";
            this.controlScadualeTest1.Size = new System.Drawing.Size(696, 667);
            this.controlScadualeTest1.TabIndex = 0;
            this.controlScadualeTest1.TestTypeId = Business_Layer_DVLD.clsTestTypes.enTestTypeId.VisionTest;
            this.controlScadualeTest1.Load += new System.EventHandler(this.controlScadualeTest1_Load);
            // 
            // FormScaduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.controlScadualeTest1);
            this.Name = "FormScaduleTest";
            this.Text = "FormScaduleTest";
            this.Load += new System.EventHandler(this.FormScaduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlScadualeTest controlScadualeTest1;
        private System.Windows.Forms.Button button1;
    }
}