using Business_Layer_DVLD;
using DTO.DVLD;
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
    public partial class FormTakeTest : Form
    {
        public FormTakeTest()
        {
            InitializeComponent();
        }

        public FormTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID= TestAppointmentID;
        }

        int _TestAppointmentID = -1;
        clsTestAppointment _TestAppointment;
        clsTest _Test;
        clsTestTypes.enTestTypeId _TestType;
        int _PersonID = -1;
        DTOLicenceClasses.enLicenceClassName _LicenseClassID = DTOLicenceClasses.enLicenceClassName.Ordinarydrivinglicense;
        int _LocalDriverLicenseID;
        private void HandleGroupBoxName()
        {
            switch((clsTestTypes.enTestTypeId)_TestAppointment._testAppointment.TestTypeID)
            {
                case clsTestTypes.enTestTypeId.VisionTest:
                    {
                        groupBox1.Text = "Vision Test";
                        break;

                    }
                case clsTestTypes.enTestTypeId.WrittenTest:
                    {

                        groupBox1.Text = "Written Test";
                        break;


                    }
                case clsTestTypes.enTestTypeId.StreetTest:
                    {

                        groupBox1.Text = "Street Test";
                        break;


                    }
                default: break;







            }





        }
        private void LoadData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if(_TestAppointment==null)
            {
                MessageBox.Show("Error,No Test Appointment With this ID " + _TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonSave.Enabled = false;
                return;

            }
            _TestType = _TestAppointment.testType._TestID;
            _PersonID = _TestAppointment._localDrivingLicenseApplications._PersonInfo._Person._PersonID;
            _LicenseClassID = _TestAppointment._localDrivingLicenseApplications.licenceClass._DTOLicenceClasses.ClassNameID;
            _LocalDriverLicenseID = _TestAppointment._testAppointment.LocalDriverLicenseID;


            HandleGroupBoxName();


            labelAppID.Text=_TestAppointment._testAppointment.LocalDriverLicenseID.ToString();
            labelClass.Text = _TestAppointment._localDrivingLicenseApplications.licenceClass._DTOLicenceClasses.ClassName;
            labelDate.Text = _TestAppointment._testAppointment.AppointmentDate.ToString();
            labelFees.Text=_TestAppointment._testAppointment.PaidFees.ToString();
            labelName.Text = _TestAppointment._localDrivingLicenseApplications._PersonInfo._Person.FullName;
            labelTrial.Text = _TestAppointment._localDrivingLicenseApplications.TotalTrialsPerTest(_TestType).ToString();
            labelTestID.Text = "Not Taken Yet";
            
            radioButtonPass.Checked = true;
            richTextBox1.Text = "";


        }

        


        
        private void FormTakeTest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private bool HandleAppStatus()
        {
            if (clsLocalDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.StreetTest,_LocalDriverLicenseID))
            {

                if (_TestAppointment._localDrivingLicenseApplications.setComplete())
                {

                    return true;
                }
                return false;
            }

            else return false;

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(_TestAppointment==null)
            {
                MessageBox.Show("Error,No Test Appointment With this ID " + _TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonSave.Enabled= false;
                return;

            }

            _Test = new clsTest();
            _Test._TestInformation.TestAppointmentID = _TestAppointment._testAppointment.TestAppointmentID;
            if(radioButtonPass.Checked)
            {
                _Test._TestInformation.TestResult = true;
            }else _Test._TestInformation.TestResult = false;

            _Test._TestInformation.UserID = clsDVLDSittings._CurrentUser._User.UserID;
            _Test._TestInformation.Notes = richTextBox1.Text;

            if (MessageBox.Show("Are You Sure you Want to End the Test ?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_Test.Save())
                {
                    MessageBox.Show("Saved,Saved Done Succefully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelTestID.Text = _Test._TestInformation.TestID.ToString();
                    buttonSave.Enabled = false;
                    richTextBox1.Enabled= false;
                    radioButtonFail.Enabled= false;
                    radioButtonPass.Enabled= false;

                    //if (HandleAppStatus())
                    //{
                    //    MessageBox.Show("Congratulation,You Passed All Tests,You can Now Issues Your License", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}


                }
                else
                {
                    Console.WriteLine("Saved Faild","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }
    }
}
