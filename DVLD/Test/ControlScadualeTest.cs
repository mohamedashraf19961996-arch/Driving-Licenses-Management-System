using Business_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ControlScadualeTest : UserControl
    {
        public ControlScadualeTest()
        {
            InitializeComponent();
        }
        clsLocalDrivingLicenseApplications _localDrivingLicenseApplications;
        int _LocalDrivingLicenseID = -1;
        
        clsTestAppointment _TestAppointment;
        int _TestAppointmentID = -1;

        clsTestTypes _TestType;
        clsTestTypes.enTestTypeId _TestTypeId = clsTestTypes.enTestTypeId.VisionTest;
        public clsTestTypes.enTestTypeId TestTypeId
        {
            get {  return _TestTypeId; }
            set { _TestTypeId = value; 
            switch(_TestTypeId)
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
                    default:break;

                }
            
            
            }
        }

        
       public enum enMode { AddNew,Update}
      public   enMode _Mode=enMode.AddNew;
        public enum enCreationMode { FirstTimeScadule,RetakeTestScadule}
        public enCreationMode _CreationMode=enCreationMode.FirstTimeScadule;

        public void LoadInfo(int LocalDrivingLicenseID,int TestAppointmentiD=-1)
        {
            if(TestAppointmentiD==-1)
            {
                _Mode = enMode.AddNew;
            }else
            {
                _Mode = enMode.Update;
            }

            _LocalDrivingLicenseID=LocalDrivingLicenseID;
            _TestAppointmentID=TestAppointmentiD;
            _localDrivingLicenseApplications = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_LocalDrivingLicenseID);
            dateTimePicker1.MinDate = DateTime.Now;
            if(_localDrivingLicenseApplications==null)
            {
                MessageBox.Show("Error,No Local Driving License Application With this ID","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                button1.Enabled = false;
                return;

            }

            if (_localDrivingLicenseApplications.DoseAttendTestType(_TestTypeId))
                _CreationMode = enCreationMode.RetakeTestScadule;

            else _CreationMode = enCreationMode.FirstTimeScadule;

            if(_CreationMode==enCreationMode.RetakeTestScadule)
            {
                labelRAppFees.Text=clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.RetakeTest)._AppFees.ToString();
                groupBoxRetakeTest.Enabled = true;
                labelTestName.Text = "Scadule Retake Test";
                labelRTAppID.Text = "0";
            }else
            {
                labelRAppFees.Text = "0";
                groupBoxRetakeTest.Enabled = false;
                
                labelTestName.Text = "Scadule Test";
                labelRTAppID.Text = "N/A";
            }

            labelAppID.Text=_localDrivingLicenseApplications._LocalDrivingLicenseAppID.ToString();
            labelClass.Text = _localDrivingLicenseApplications.licenceClass._DTOLicenceClasses.ClassName;
            labelName.Text = _localDrivingLicenseApplications._PersonInfo._Person.FullName;
            labelTrial.Text=_localDrivingLicenseApplications.TotalTrialsPerTest(_TestTypeId).ToString();

            if(_Mode==enMode.AddNew)
            {
                labelFees.Text=clsTestTypes.Find(_TestTypeId)._TestFees.ToString();
                dateTimePicker1.Value = DateTime.Now;
                labelRTAppID.Text= "N/A";
                _TestAppointment=new clsTestAppointment();

            }else if(_Mode==enMode.Update)
            {
                if (!LoadTestAppointmentData())
                    return;

            }
            decimal TotalFees = decimal.Parse(labelFees.Text) + decimal.Parse(labelRAppFees.Text);
            labelTotalFees.Text = TotalFees.ToString();

            if (!HandleActiveTestAppointment())
                return;
            if (!HandleAppointmentLockedConstrained())
                return;
            if (!HandlePreviousTest())
                return;

            if (!HandlePassTest())
                return;
        }

        private bool LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show($"Error,No Appointment with ID {_TestAppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = false;
                return false;
            }

            labelFees.Text = _TestAppointment._testAppointment.PaidFees.ToString();

            if (DateTime.Compare(DateTime.Now, _TestAppointment._testAppointment.AppointmentDate) < 0)
            {

                dateTimePicker1.MinDate = DateTime.Now;

            }
            else { dateTimePicker1.MinDate = _TestAppointment._testAppointment.AppointmentDate; }

            dateTimePicker1.Value = _TestAppointment._testAppointment.AppointmentDate;

            if(_TestAppointment._testAppointment.RetakeTestID==-1)
            {
                labelRTAppID.Text = "N/A";
                labelRAppFees.Text = "0";
            }else
            {
                labelRTAppID.Text = _TestAppointment._ApplicationRetakeTest._application.ApplicationID.ToString();
                labelRAppFees.Text = _TestAppointment._ApplicationRetakeTest._application.PaidFees.ToString();
                labelTestName.Text = "Scadule Retake Test";
                groupBoxRetakeTest.Enabled = true;
            }

            return true;

        }
        
        private bool HandleActiveTestAppointment()
        {
            if (_Mode == enMode.AddNew && _localDrivingLicenseApplications.IsThereAnActiveScaduledTest(_TestTypeId))
            {
                labelMessage.Visible = true;
                labelMessage.Text = "Person Already have An Active Appointment for this test Appointment";
                button1.Enabled = false;
                dateTimePicker1.Enabled = false;
             
                return false;


            }
            //else
            //{
            //    labelMessage.Visible = false;

                return true;
            //}


        }
        
        private bool HandleAppointmentLockedConstrained()
        {
            if(_TestAppointment._testAppointment.ISLocked)
            {
                labelMessage.Visible = true;
                labelMessage.Text = "Person Already Sat For this Test Appointment";
                button1.Enabled = false;
                dateTimePicker1.Enabled=false;
                return false;

            }else
            {
                labelMessage.Visible = false;
                return true;
            }


        }
        private bool HandlePreviousTest()
        {
            switch(_TestTypeId)
            {
                case clsTestTypes.enTestTypeId.VisionTest:
                    {
                        labelMessage.Visible = false;
                        
                        return true;
                    }
                case clsTestTypes.enTestTypeId.WrittenTest:
                    {
                        if(!_localDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.VisionTest))
                        {
                            labelMessage.Visible=true;
                            labelMessage.Text = "Cannot Scadule,Vision Test Should be Passed First";
                            button1.Enabled = false;
                            dateTimePicker1.Enabled=false;
                            return false;
                        }else
                        {
                            labelMessage.Visible=false;
                            button1.Enabled=true;
                            dateTimePicker1.Enabled = true;
                            
                        }
                        return true;


                    }
                case clsTestTypes.enTestTypeId.StreetTest:
                    {
                        if (!_localDrivingLicenseApplications.DosePassTestType(clsTestTypes.enTestTypeId.WrittenTest))
                        {
                            labelMessage.Visible = true;
                            labelMessage.Text = "Cannot Scadule,Written Test Should be Passed First";
                            button1.Enabled = false;
                            dateTimePicker1.Enabled = false;
                            return false;
                        }
                        else
                        {
                            labelMessage.Visible = false;
                            button1.Enabled = true;
                            dateTimePicker1.Enabled = true;

                        }
                        return true;




                    }
                default:return false;





            }





        }
        private bool HandlePassTest()
        {
            if(_Mode==enMode.AddNew&&clsLocalDrivingLicenseApplications.DosePassTestType(_TestTypeId,_LocalDrivingLicenseID))
            {
                labelMessage.Enabled = true;
                labelMessage.Text = "this Test has been Passed!";
                button1.Enabled = false;
                dateTimePicker1.Enabled = false;
                return false;
            }

            return true;


        }
        private bool HandleRetakeTest()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestScadule)
            {

                clsApplications application = new clsApplications();

                application._application.ApplicantPersonID = _localDrivingLicenseApplications._application.ApplicantPersonID;
                application._application.ApplicationDate = DateTime.Now;
                application._application.ApplicationStatus = DTOApplication.enApplicationStatus.New;
                application._application.ApplicationTypeID = DTOApplication.enAppType.RetakeTest;
                application._application.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;
                application._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.RetakeTest)._AppFees;
                application._application.LastStatusDate = DateTime.Now;

                if (!application.Save())
                {
                    _TestAppointment._testAppointment.RetakeTestID = -1;
                    MessageBox.Show("Failed to Create Application", "Failed");
                    return false;
                }


                _TestAppointment._testAppointment.RetakeTestID = application._application.ApplicationID;

             
            }

            return true;


        }

        
        private void ControlScadualeTest_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!HandleRetakeTest())
                return;
            _TestAppointment._testAppointment.TestTypeID = (int)_TestTypeId;
            _TestAppointment._testAppointment.LocalDriverLicenseID = _LocalDrivingLicenseID;
            _TestAppointment._testAppointment.UserID = clsDVLDSittings._CurrentUser._User.UserID;
            _TestAppointment._testAppointment.AppointmentDate = dateTimePicker1.Value;
            _TestAppointment._testAppointment.PaidFees = decimal.Parse(labelFees.Text);

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Succefully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
            else
            { MessageBox.Show("Error,Data Saved Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
