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
    public partial class FormScaduleTest : Form
    {
        public FormScaduleTest()
        {
            InitializeComponent();

        }
        //public FormScaduleTest(int LocaLDrivingLicenseID,clsTestTypes.enTestTypeId testTypeId)
        //{
        //    InitializeComponent();
        //    _LocaLDrivingLicenseID= LocaLDrivingLicenseID;
        //    _testTypeId= testTypeId;
        //}
        public FormScaduleTest(int LocaLDrivingLicenseID ,clsTestTypes.enTestTypeId testTypeId, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocaLDrivingLicenseID = LocaLDrivingLicenseID;
            _testTypeId = testTypeId;
            _TestAppointmentID= TestAppointmentID;
        }
        private int _LocaLDrivingLicenseID=-1;
        private clsTestTypes.enTestTypeId _testTypeId=clsTestTypes.enTestTypeId.VisionTest;
        private int _TestAppointmentID=-1;
        private void FormScaduleTest_Load(object sender, EventArgs e)
        {
            if (_TestAppointmentID == -1)
            {
                controlScadualeTest1.TestTypeId = _testTypeId;
                controlScadualeTest1.LoadInfo(_LocaLDrivingLicenseID,-1);
            }else {
                controlScadualeTest1.TestTypeId = _testTypeId;
                controlScadualeTest1.LoadInfo(_LocaLDrivingLicenseID,_TestAppointmentID);
            }
        }

        private void controlScadualeTest1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
