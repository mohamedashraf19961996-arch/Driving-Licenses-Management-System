namespace DVLD
{
    partial class FormAddNewUser
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
            this.labelAddNewUser = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePersonalInfo = new System.Windows.Forms.TabPage();
            this.buttonNext = new System.Windows.Forms.Button();
            this.controlPersonalInformationWithFilter1 = new DVLD.ControlPersonalInformationWithFilter();
            this.tabPageUserInfo = new System.Windows.Forms.TabPage();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelUserID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPagePersonalInfo.SuspendLayout();
            this.tabPageUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAddNewUser
            // 
            this.labelAddNewUser.AutoSize = true;
            this.labelAddNewUser.Font = new System.Drawing.Font("Tahoma", 13F);
            this.labelAddNewUser.Location = new System.Drawing.Point(521, 21);
            this.labelAddNewUser.Name = "labelAddNewUser";
            this.labelAddNewUser.Size = new System.Drawing.Size(176, 31);
            this.labelAddNewUser.TabIndex = 0;
            this.labelAddNewUser.Text = "Add New User";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePersonalInfo);
            this.tabControl1.Controls.Add(this.tabPageUserInfo);
            this.tabControl1.Location = new System.Drawing.Point(118, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1008, 472);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPagePersonalInfo
            // 
            this.tabPagePersonalInfo.Controls.Add(this.buttonNext);
            this.tabPagePersonalInfo.Controls.Add(this.controlPersonalInformationWithFilter1);
            this.tabPagePersonalInfo.Location = new System.Drawing.Point(4, 28);
            this.tabPagePersonalInfo.Name = "tabPagePersonalInfo";
            this.tabPagePersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersonalInfo.Size = new System.Drawing.Size(1000, 440);
            this.tabPagePersonalInfo.TabIndex = 0;
            this.tabPagePersonalInfo.Text = "Personal Info";
            this.tabPagePersonalInfo.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(837, 377);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(95, 49);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // controlPersonalInformationWithFilter1
            // 
            this.controlPersonalInformationWithFilter1.FilterEnabled = true;
            this.controlPersonalInformationWithFilter1.Location = new System.Drawing.Point(-13, 3);
            this.controlPersonalInformationWithFilter1.Name = "controlPersonalInformationWithFilter1";
            this.controlPersonalInformationWithFilter1.ShowAddNewPerson = true;
            this.controlPersonalInformationWithFilter1.Size = new System.Drawing.Size(1091, 483);
            this.controlPersonalInformationWithFilter1.TabIndex = 0;
            // 
            // tabPageUserInfo
            // 
            this.tabPageUserInfo.Controls.Add(this.buttonClose);
            this.tabPageUserInfo.Controls.Add(this.buttonSave);
            this.tabPageUserInfo.Controls.Add(this.textBoxConfirmPassword);
            this.tabPageUserInfo.Controls.Add(this.textBoxPassword);
            this.tabPageUserInfo.Controls.Add(this.textBoxUserName);
            this.tabPageUserInfo.Controls.Add(this.checkBoxIsActive);
            this.tabPageUserInfo.Controls.Add(this.label6);
            this.tabPageUserInfo.Controls.Add(this.label5);
            this.tabPageUserInfo.Controls.Add(this.label4);
            this.tabPageUserInfo.Controls.Add(this.labelUserID);
            this.tabPageUserInfo.Controls.Add(this.label2);
            this.tabPageUserInfo.Location = new System.Drawing.Point(4, 28);
            this.tabPageUserInfo.Name = "tabPageUserInfo";
            this.tabPageUserInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUserInfo.Size = new System.Drawing.Size(1000, 440);
            this.tabPageUserInfo.TabIndex = 1;
            this.tabPageUserInfo.Text = "User Info";
            this.tabPageUserInfo.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(302, 299);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(196, 44);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(518, 299);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(196, 44);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(164, 221);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(215, 27);
            this.textBoxConfirmPassword.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(164, 172);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(215, 27);
            this.textBoxPassword.TabIndex = 7;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(164, 121);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(215, 27);
            this.textBoxUserName.TabIndex = 6;
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Location = new System.Drawing.Point(191, 271);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(96, 23);
            this.checkBoxIsActive.TabIndex = 5;
            this.checkBoxIsActive.Text = "Is Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Confirm Password :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "User Name : ";
            // 
            // labelUserID
            // 
            this.labelUserID.AutoSize = true;
            this.labelUserID.Location = new System.Drawing.Point(178, 72);
            this.labelUserID.Name = "labelUserID";
            this.labelUserID.Size = new System.Drawing.Size(45, 19);
            this.labelUserID.TabIndex = 1;
            this.labelUserID.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID :";
            // 
            // FormAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelAddNewUser);
            this.Name = "FormAddNewUser";
            this.Text = "FormAddNewUser";
            this.Load += new System.EventHandler(this.FormAddNewUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePersonalInfo.ResumeLayout(false);
            this.tabPageUserInfo.ResumeLayout(false);
            this.tabPageUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddNewUser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePersonalInfo;
        private System.Windows.Forms.TabPage tabPageUserInfo;
        private ControlPersonalInformationWithFilter controlPersonalInformationWithFilter1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
    }
}