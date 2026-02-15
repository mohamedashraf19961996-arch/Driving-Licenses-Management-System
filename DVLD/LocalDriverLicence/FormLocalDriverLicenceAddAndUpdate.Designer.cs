namespace DVLD
{
    partial class FormLocalDriverLicenceAddAndUpdate
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.controlPersonalInformationWithFilter1 = new DVLD.ControlPersonalInformationWithFilter();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxLicenceClass = new System.Windows.Forms.ComboBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelCreatedByUser = new System.Windows.Forms.Label();
            this.labelAppFees = new System.Windows.Forms.Label();
            this.labelAppDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAppID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelTitle.ForeColor = System.Drawing.Color.Red;
            this.labelTitle.Location = new System.Drawing.Point(250, 18);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(511, 36);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = " New Local Driver Licence Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(52, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 520);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.controlPersonalInformationWithFilter1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(959, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(770, 410);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 62);
            this.button3.TabIndex = 1;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // controlPersonalInformationWithFilter1
            // 
            this.controlPersonalInformationWithFilter1.FilterEnabled = true;
            this.controlPersonalInformationWithFilter1.Location = new System.Drawing.Point(6, 24);
            this.controlPersonalInformationWithFilter1.Name = "controlPersonalInformationWithFilter1";
            this.controlPersonalInformationWithFilter1.ShowAddNewPerson = true;
            this.controlPersonalInformationWithFilter1.Size = new System.Drawing.Size(925, 406);
            this.controlPersonalInformationWithFilter1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBoxLicenceClass);
            this.tabPage2.Controls.Add(this.buttonClose);
            this.tabPage2.Controls.Add(this.buttonSave);
            this.tabPage2.Controls.Add(this.labelCreatedByUser);
            this.tabPage2.Controls.Add(this.labelAppFees);
            this.tabPage2.Controls.Add(this.labelAppDate);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.labelAppID);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(959, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBoxLicenceClass
            // 
            this.comboBoxLicenceClass.FormattingEnabled = true;
            this.comboBoxLicenceClass.Location = new System.Drawing.Point(279, 146);
            this.comboBoxLicenceClass.Name = "comboBoxLicenceClass";
            this.comboBoxLicenceClass.Size = new System.Drawing.Size(178, 27);
            this.comboBoxLicenceClass.TabIndex = 13;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(594, 418);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(155, 56);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(771, 418);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(155, 56);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelCreatedByUser
            // 
            this.labelCreatedByUser.AutoSize = true;
            this.labelCreatedByUser.Location = new System.Drawing.Point(275, 246);
            this.labelCreatedByUser.Name = "labelCreatedByUser";
            this.labelCreatedByUser.Size = new System.Drawing.Size(45, 19);
            this.labelCreatedByUser.TabIndex = 10;
            this.labelCreatedByUser.Text = "[???]";
            // 
            // labelAppFees
            // 
            this.labelAppFees.AutoSize = true;
            this.labelAppFees.Location = new System.Drawing.Point(275, 196);
            this.labelAppFees.Name = "labelAppFees";
            this.labelAppFees.Size = new System.Drawing.Size(45, 19);
            this.labelAppFees.TabIndex = 9;
            this.labelAppFees.Text = "[???]";
            // 
            // labelAppDate
            // 
            this.labelAppDate.AutoSize = true;
            this.labelAppDate.Location = new System.Drawing.Point(275, 100);
            this.labelAppDate.Name = "labelAppDate";
            this.labelAppDate.Size = new System.Drawing.Size(45, 19);
            this.labelAppDate.TabIndex = 8;
            this.labelAppDate.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(65, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Created By User :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "Application Fees :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Licence Class :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Application Date :";
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Location = new System.Drawing.Point(275, 51);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(45, 19);
            this.labelAppID.TabIndex = 3;
            this.labelAppID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Licence App ID :";
            // 
            // FormLocalDriverLicenceAddAndUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1044, 613);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTitle);
            this.Name = "FormLocalDriverLicenceAddAndUpdate";
            this.Text = "FormLocalDriverLicenceAddAndUpdate";
            this.Load += new System.EventHandler(this.FormLocalDriverLicenceAddAndUpdate_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ControlPersonalInformationWithFilter controlPersonalInformationWithFilter1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAppID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelCreatedByUser;
        private System.Windows.Forms.Label labelAppFees;
        private System.Windows.Forms.Label labelAppDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxLicenceClass;
    }
}