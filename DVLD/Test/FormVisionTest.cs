using Business_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FormVisionTest : Form
    {
        public FormVisionTest()
        {
            InitializeComponent();

        }

        public FormVisionTest(int LocalDrivingLicenseAppID,clsTestTypes.enTestTypeId testTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID=LocalDrivingLicenseAppID;
            _testTypeID=testTypeID;

        }
        
        int _LocalDrivingLicenseAppID=-1;
        private  DataTable DatatableAllTest;
        private clsTestTypes.enTestTypeId _testTypeID=clsTestTypes.enTestTypeId.VisionTest;
        
        private void _LoadControlAppInfo()
        {
            controlLocalDriverLicenseInformation1.LoadData(_LocalDrivingLicenseAppID); 
        }
        private void FormLocalDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            
            LoadDataGridView();
        }

        private void HandleFormName()
        {
            switch (_testTypeID)
            {
                case clsTestTypes.enTestTypeId.VisionTest:
                    {
                        this.Text = "Form Vision Test";
                        label1.Text = "Vision Test";
                        break;
                    }
                case clsTestTypes.enTestTypeId.WrittenTest:
                    {
                        this.Text = "Form Written Test";
                        label1.Text = "Written Test";
                        break;
                    }
                case clsTestTypes.enTestTypeId.StreetTest:
                    {
                        this.Text = "Form Street Test";
                        label1.Text = "Street Test";
                        break;
                    }



            }



        }
        private void LoadDataGridView()
        {
            _LoadControlAppInfo();
            HandleFormName();
            DatatableAllTest = clsTestAppointment.GetAllTestAppointmentForTestType(_testTypeID, _LocalDrivingLicenseAppID);
            dataGridView1.DataSource= DatatableAllTest;
            labelRecords.Text=dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Appointment ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "Appointment Date";
                dataGridView1.Columns[1].Width = 180;

                dataGridView1.Columns[2].HeaderText = "Paid Fees";
                dataGridView1.Columns[2].Width = 70;

                dataGridView1.Columns[3].HeaderText = "Is Locked";
                dataGridView1.Columns[3].Width = 50;

                dataGridView1.Columns[4].HeaderText = "Result";
                dataGridView1.Columns[4].Width = 50;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            Form Form = new FormScaduleTest(_LocalDrivingLicenseAppID,_testTypeID);
            Form.ShowDialog();
            FormLocalDrivingLicenseAppInfo_Load(null, null);



        }

        
        private void editTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form Form = new FormScaduleTest(_LocalDrivingLicenseAppID,_testTypeID, (int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormLocalDrivingLicenseAppInfo_Load(null, null);





        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            Form Form = new FormTakeTest((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormLocalDrivingLicenseAppInfo_Load(null, null);

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bool IsLocked = ((bool)dataGridView1.CurrentRow.Cells[3].Value);
                 if(IsLocked)
            {
                retakeTestToolStripMenuItem.Enabled =false;
                editTestToolStripMenuItem.Enabled = false;

            }else
            {
                retakeTestToolStripMenuItem.Enabled = true;
                editTestToolStripMenuItem.Enabled = true;

            }


        }
    }
}
