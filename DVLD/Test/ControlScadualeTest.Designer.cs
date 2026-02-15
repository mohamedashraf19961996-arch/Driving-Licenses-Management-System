namespace DVLD
{
    partial class ControlScadualeTest
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.labelFees = new System.Windows.Forms.Label();
            this.labelTrial = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelAppID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTestName = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxRetakeTest = new System.Windows.Forms.GroupBox();
            this.labelRTAppID = new System.Windows.Forms.Label();
            this.labelRAppFees = new System.Windows.Forms.Label();
            this.labelTotalFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxRetakeTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelMessage);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.labelFees);
            this.groupBox1.Controls.Add(this.labelTrial);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Controls.Add(this.labelClass);
            this.groupBox1.Controls.Add(this.labelAppID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelTestName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Type";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.labelMessage.ForeColor = System.Drawing.Color.Red;
            this.labelMessage.Location = new System.Drawing.Point(80, 86);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(424, 19);
            this.labelMessage.TabIndex = 14;
            this.labelMessage.Text = "Can not Scadule,Vision Test Should Be Passed First";
            this.labelMessage.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(120, 310);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 27);
            this.dateTimePicker1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(539, 593);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 55);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFees
            // 
            this.labelFees.AutoSize = true;
            this.labelFees.Location = new System.Drawing.Point(147, 351);
            this.labelFees.Name = "labelFees";
            this.labelFees.Size = new System.Drawing.Size(45, 19);
            this.labelFees.TabIndex = 11;
            this.labelFees.Text = "[???]";
            // 
            // labelTrial
            // 
            this.labelTrial.AutoSize = true;
            this.labelTrial.Location = new System.Drawing.Point(147, 280);
            this.labelTrial.Name = "labelTrial";
            this.labelTrial.Size = new System.Drawing.Size(45, 19);
            this.labelTrial.TabIndex = 10;
            this.labelTrial.Text = "[???]";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(147, 234);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(45, 19);
            this.labelName.TabIndex = 9;
            this.labelName.Text = "[???]";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(147, 189);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(45, 19);
            this.labelClass.TabIndex = 8;
            this.labelClass.Text = "[???]";
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Location = new System.Drawing.Point(147, 149);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(45, 19);
            this.labelAppID.TabIndex = 7;
            this.labelAppID.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fees :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Date :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Trial :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "D.Class :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "D.L.App.ID :";
            // 
            // labelTestName
            // 
            this.labelTestName.AutoSize = true;
            this.labelTestName.Font = new System.Drawing.Font("Tahoma", 20F);
            this.labelTestName.ForeColor = System.Drawing.Color.Red;
            this.labelTestName.Location = new System.Drawing.Point(179, 23);
            this.labelTestName.Name = "labelTestName";
            this.labelTestName.Size = new System.Drawing.Size(243, 48);
            this.labelTestName.TabIndex = 0;
            this.labelTestName.Text = "Scadule Test";
            // 
            // groupBoxRetakeTest
            // 
            this.groupBoxRetakeTest.Controls.Add(this.labelRTAppID);
            this.groupBoxRetakeTest.Controls.Add(this.labelRAppFees);
            this.groupBoxRetakeTest.Controls.Add(this.labelTotalFees);
            this.groupBoxRetakeTest.Controls.Add(this.label10);
            this.groupBoxRetakeTest.Controls.Add(this.label9);
            this.groupBoxRetakeTest.Controls.Add(this.label8);
            this.groupBoxRetakeTest.Location = new System.Drawing.Point(3, 404);
            this.groupBoxRetakeTest.Name = "groupBoxRetakeTest";
            this.groupBoxRetakeTest.Size = new System.Drawing.Size(674, 171);
            this.groupBoxRetakeTest.TabIndex = 1;
            this.groupBoxRetakeTest.TabStop = false;
            this.groupBoxRetakeTest.Text = "Retake Test Info";
            // 
            // labelRTAppID
            // 
            this.labelRTAppID.AutoSize = true;
            this.labelRTAppID.Location = new System.Drawing.Point(127, 115);
            this.labelRTAppID.Name = "labelRTAppID";
            this.labelRTAppID.Size = new System.Drawing.Size(45, 19);
            this.labelRTAppID.TabIndex = 20;
            this.labelRTAppID.Text = "[???]";
            // 
            // labelRAppFees
            // 
            this.labelRAppFees.AutoSize = true;
            this.labelRAppFees.Location = new System.Drawing.Point(127, 56);
            this.labelRAppFees.Name = "labelRAppFees";
            this.labelRAppFees.Size = new System.Drawing.Size(45, 19);
            this.labelRAppFees.TabIndex = 19;
            this.labelRAppFees.Text = "[???]";
            // 
            // labelTotalFees
            // 
            this.labelTotalFees.AutoSize = true;
            this.labelTotalFees.Location = new System.Drawing.Point(405, 56);
            this.labelTotalFees.Name = "labelTotalFees";
            this.labelTotalFees.Size = new System.Drawing.Size(45, 19);
            this.labelTotalFees.TabIndex = 18;
            this.labelTotalFees.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(287, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Total Fees :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "R,T,App ID :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "R.App Fees :";
            // 
            // ControlScadualeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxRetakeTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "ControlScadualeTest";
            this.Size = new System.Drawing.Size(694, 696);
            this.Load += new System.EventHandler(this.ControlScadualeTest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxRetakeTest.ResumeLayout(false);
            this.groupBoxRetakeTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelFees;
        private System.Windows.Forms.Label labelTrial;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelAppID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTestName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.GroupBox groupBoxRetakeTest;
        private System.Windows.Forms.Label labelRTAppID;
        private System.Windows.Forms.Label labelRAppFees;
        private System.Windows.Forms.Label labelTotalFees;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
