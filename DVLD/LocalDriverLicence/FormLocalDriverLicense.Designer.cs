namespace DVLD
{
    partial class FormLocalDriverLicense
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaduleTestVisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelRecords = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxfilterBy = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.showLicenseInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 240);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1261, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailesToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scaduleTestToolStripMenuItem,
            this.issueLicenseFirstTimeToolStripMenuItem,
            this.showLicenseInformationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(291, 261);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApplicationDetailesToolStripMenuItem
            // 
            this.showApplicationDetailesToolStripMenuItem.Name = "showApplicationDetailesToolStripMenuItem";
            this.showApplicationDetailesToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.showApplicationDetailesToolStripMenuItem.Text = "Show Application Detailes";
            this.showApplicationDetailesToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailesToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scaduleTestToolStripMenuItem
            // 
            this.scaduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaduleTestVisionToolStripMenuItem,
            this.scaduleWrittenTestToolStripMenuItem,
            this.scaduleStreetTestToolStripMenuItem});
            this.scaduleTestToolStripMenuItem.Name = "scaduleTestToolStripMenuItem";
            this.scaduleTestToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.scaduleTestToolStripMenuItem.Text = "Scadule Test";
            // 
            // scaduleTestVisionToolStripMenuItem
            // 
            this.scaduleTestVisionToolStripMenuItem.Name = "scaduleTestVisionToolStripMenuItem";
            this.scaduleTestVisionToolStripMenuItem.Size = new System.Drawing.Size(273, 34);
            this.scaduleTestVisionToolStripMenuItem.Text = "Scadule Vision Test ";
            this.scaduleTestVisionToolStripMenuItem.Click += new System.EventHandler(this.scaduleTestVisionToolStripMenuItem_Click);
            // 
            // scaduleWrittenTestToolStripMenuItem
            // 
            this.scaduleWrittenTestToolStripMenuItem.Name = "scaduleWrittenTestToolStripMenuItem";
            this.scaduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(273, 34);
            this.scaduleWrittenTestToolStripMenuItem.Text = "Scadule Written Test";
            this.scaduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scaduleWrittenTestToolStripMenuItem_Click);
            // 
            // scaduleStreetTestToolStripMenuItem
            // 
            this.scaduleStreetTestToolStripMenuItem.Name = "scaduleStreetTestToolStripMenuItem";
            this.scaduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(273, 34);
            this.scaduleStreetTestToolStripMenuItem.Text = "Scadule Street Test";
            this.scaduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scaduleStreetTestToolStripMenuItem_Click);
            // 
            // issueLicenseFirstTimeToolStripMenuItem
            // 
            this.issueLicenseFirstTimeToolStripMenuItem.Name = "issueLicenseFirstTimeToolStripMenuItem";
            this.issueLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.issueLicenseFirstTimeToolStripMenuItem.Text = "Issue License (First Time)";
            this.issueLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(347, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Driver License Applications";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.Location = new System.Drawing.Point(33, 594);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "#Records :";
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Location = new System.Drawing.Point(163, 599);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(45, 19);
            this.labelRecords.TabIndex = 4;
            this.labelRecords.Text = "[???]";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1158, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 71);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxfilterBy
            // 
            this.comboBoxfilterBy.FormattingEnabled = true;
            this.comboBoxfilterBy.Location = new System.Drawing.Point(106, 193);
            this.comboBoxfilterBy.Name = "comboBoxfilterBy";
            this.comboBoxfilterBy.Size = new System.Drawing.Size(202, 27);
            this.comboBoxfilterBy.TabIndex = 6;
            this.comboBoxfilterBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxfilterBy_SelectedIndexChanged);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(337, 193);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(231, 27);
            this.textBoxFilter.TabIndex = 7;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // showLicenseInformationToolStripMenuItem
            // 
            this.showLicenseInformationToolStripMenuItem.Name = "showLicenseInformationToolStripMenuItem";
            this.showLicenseInformationToolStripMenuItem.Size = new System.Drawing.Size(290, 32);
            this.showLicenseInformationToolStripMenuItem.Text = "Show License Information";
            this.showLicenseInformationToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInformationToolStripMenuItem_Click);
            // 
            // FormLocalDriverLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 640);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.comboBoxfilterBy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormLocalDriverLicense";
            this.Text = "FormLocalDriverLicense";
            this.Load += new System.EventHandler(this.FormLocalDriverLicense_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxfilterBy;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaduleTestVisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInformationToolStripMenuItem;
    }
}