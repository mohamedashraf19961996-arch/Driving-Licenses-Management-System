using Business_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD
{
    public partial class FormLocalDriverLicense : Form
    {
        public FormLocalDriverLicense()
        {
            InitializeComponent();
            FillComboboxFilter();
        }


        DataTable _datatable;
        private int _LocalDriverLicenseID;
        private clsLocalDrivingLicenseApplications LocalDrivingLicenseApplications;
        private int PersonID;
        private DTOLicenceClasses.enLicenceClassName ClassName;

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form = new FormLocalDriverLicenceAddAndUpdate();
            Form.ShowDialog();
            LoadData();
        }

        private void ComboBoxChoase()
        {
            string Filterby = "";
            switch (comboBoxfilterBy.Text)
            {

                case "National No":
                    {
                        Filterby = "NationalNo";
                        break;
                    }
                case "License App ID":
                    {

                        Filterby = "LocalDrivingLicenseApplicationID";
                        break;
                    }
                case "Full Name":
                    {

                        Filterby = "FullName";
                        break;
                    }
                case "Status":
                    {
                        Filterby = "Status";
                        break;
                    }

                default: { Filterby = "None"; break; }


            }

            if (Filterby == "None" || textBoxFilter.Text.Trim() == "")
            {
                _datatable.DefaultView.RowFilter = "";
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (Filterby == "LocalDrivingLicenseApplicationID")
            {

                if (int.TryParse(textBoxFilter.Text, out int value))
                {
                    _datatable.DefaultView.RowFilter = string.Format("[{0}]={1}", Filterby, value);
                    labelRecords.Text = dataGridView1.Rows.Count.ToString();
                    return;
                }
            }
            else
            {

                _datatable.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", Filterby, textBoxFilter.Text.Trim());
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

        }
        private void LoadData()
        {
            

            comboBoxfilterBy.SelectedIndex = 0;
            _datatable = clsLocalDriverLicenseView.GetAllView();
            dataGridView1.DataSource = _datatable;
            labelRecords.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "L D L App Id";
                dataGridView1.Columns[0].Width = 50;

                dataGridView1.Columns[1].HeaderText = "Class Name";
                dataGridView1.Columns[1].Width = 180
                    ;

                dataGridView1.Columns[2].HeaderText = "National No";
                dataGridView1.Columns[2].Width = 50;


                dataGridView1.Columns[3].HeaderText = "Full Name";
                dataGridView1.Columns[3].Width = 210;


                dataGridView1.Columns[4].HeaderText = "Application Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Passed Test Count";
                dataGridView1.Columns[5].Width = 50;

                dataGridView1.Columns[6].HeaderText = "Status";
                dataGridView1.Columns[6].Width = 70;

            }



        }

        private void FillComboboxFilter()
        {
            comboBoxfilterBy.Items.Add("None");
            comboBoxfilterBy.Items.Add("National No");
            comboBoxfilterBy.Items.Add("License App ID");
            comboBoxfilterBy.Items.Add("Full Name");
            comboBoxfilterBy.Items.Add("Status");





        }

        private void FormLocalDriverLicense_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void comboBoxfilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxFilter.Enabled = (comboBoxfilterBy.Text != "None");


            if (textBoxFilter.Visible)
            {
                textBoxFilter.Text = "";
                textBoxFilter.Focus();
            }


        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            ComboBoxChoase();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void scaduleTestVisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormVisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestTypeId.VisionTest);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);

        }

        private void showApplicationDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormLocalLicenseInformation((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormLocalDriverLicenceAddAndUpdate((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);

        }

        private void scaduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormVisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestTypeId.WrittenTest);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);
        }

        private void scaduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormVisionTest((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestTypes.enTestTypeId.StreetTest);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _LocalDriverLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_LocalDriverLicenseID);
           bool VisionTestPass = clsLocalDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.VisionTest, _LocalDriverLicenseID);
            bool WrittenTestPass= clsLocalDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.WrittenTest, _LocalDriverLicenseID);
            bool StreetTestPass = clsLocalDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.StreetTest, _LocalDriverLicenseID);
          
            scaduleTestVisionToolStripMenuItem.Enabled = !(VisionTestPass) && !(WrittenTestPass) && !(StreetTestPass);
            scaduleWrittenTestToolStripMenuItem.Enabled = (VisionTestPass) && !(WrittenTestPass) && !(StreetTestPass);
            scaduleStreetTestToolStripMenuItem.Enabled = (VisionTestPass) && (WrittenTestPass) && !(StreetTestPass);
            issueLicenseFirstTimeToolStripMenuItem.Enabled = (VisionTestPass) && (WrittenTestPass) && (StreetTestPass);
           
            switch (dataGridView1.CurrentRow.Cells[6].Value)

            {
                case "Completed":
                    {
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        editApplicationToolStripMenuItem.Enabled = false;
                        scaduleTestToolStripMenuItem.Enabled = false;
                        issueLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseInformationToolStripMenuItem.Enabled =true;


                        break;
                    }
                case "Cancelled":
                    {


                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        editApplicationToolStripMenuItem.Enabled = false;
                        scaduleTestToolStripMenuItem.Enabled = false;
                        showLicenseInformationToolStripMenuItem.Enabled = false;

                        break;

                    }
                case "New":
                    {
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        editApplicationToolStripMenuItem.Enabled = true;
                        scaduleTestToolStripMenuItem.Enabled = true;
                        showLicenseInformationToolStripMenuItem.Enabled = false;

                        break;



                    }

            }









        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete,Are you Sure you want to delete this Application", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID((int)dataGridView1.CurrentRow.Cells[0].Value);
                if (LocalDrivingLicenseApplications != null)
                {
                    if (LocalDrivingLicenseApplications.Delete())
                    {
                        MessageBox.Show("Information,Deleting Done Succefully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Information,Deleting Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }
                FormLocalDriverLicense_Load(null, null);


            }





        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Cancel,Are you Sure you want to Cancel this Application", "Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID((int)dataGridView1.CurrentRow.Cells[0].Value);
                if (LocalDrivingLicenseApplications != null)
                {
                    if (LocalDrivingLicenseApplications.Cancel())

                        MessageBox.Show("Updated Status Done Succefully", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                        MessageBox.Show("Updated Status Failed", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormLocalDriverLicense_Load(null, null);

                }
            }
        }

        private void issueLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormIssueLiecenseForFirstTime((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormLocalDriverLicense_Load(null, null);
            

        }

        private void showLicenseInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LocalDriverLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            LocalDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_LocalDriverLicenseID);

            if (LocalDrivingLicenseApplications == null)
            {
                MessageBox.Show("No Application With this ID");

                return;
            }
            PersonID = LocalDrivingLicenseApplications._PersonInfo._Person._PersonID;
            ClassName = (DTOLicenceClasses.enLicenceClassName)LocalDrivingLicenseApplications._LicenseClassID;

            clsLicenses license = clsLicenses.getLicensebyPersonLicenseClass(PersonID, ClassName);

            if (license == null)
            {
                MessageBox.Show("No License for this Application");

                return;
            }


            Form Form = new FormShowLicenseInfo(license.LicenseInfo.LicenseID);

                Form.ShowDialog();


}
        
    }
} 
