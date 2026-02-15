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
    public partial class FormLocalDriverLicenceAddAndUpdate : Form
    {
        public FormLocalDriverLicenceAddAndUpdate()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public FormLocalDriverLicenceAddAndUpdate(int LocalDriverLicenceAppId)
        {
            InitializeComponent();
            _LocalDriverLicenceAppID=LocalDriverLicenceAppId;
            _Mode = enMode.Update;
        }
        int _LocalDriverLicenceAppID;
        int _PersonID;
        enum enMode { AddNew,Update}
        enMode _Mode;
        clsLocalDrivingLicenseApplications LocalDrivingLicenseApp;
        DateTime _AppDate;
        clsPeople Person;
        private void ResetDefault()
        {
            comboBoxLicenceClass.ValueMember = "LicenseClassID";
            comboBoxLicenceClass.DisplayMember = "ClassName";
            comboBoxLicenceClass.DataSource = clsLicenceClasses.GetAllLicenceClasses();

                labelAppDate.Text = "[???]";
            labelAppFees.Text = "[???]";
            labelAppID.Text = "[???]";
            labelCreatedByUser.Text = "[???]";
                labelTitle.Text = " New Local Driver Licence Application";
            controlPersonalInformationWithFilter1.FilterEnabled = true;
            comboBoxLicenceClass.Enabled = false;
            buttonSave.Enabled = false;
            button3.Enabled = false;
            labelAppDate.Text = DateTime.Now.ToShortDateString();
            labelAppFees.Text=clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.NewDrivingLicence)._AppFees.ToString();
            labelCreatedByUser.Text = "user";
            controlPersonalInformationWithFilter1.OnPersonSelection += ControlPersonalInformationWithFilter1_OnPersonSelection;
            comboBoxLicenceClass.SelectedIndex = 2;
        }

        private void ControlPersonalInformationWithFilter1_OnPersonSelection(int obj)
        {
            _PersonID = obj;
            button3.Enabled = true;
        }

        private void _LoadData()
        {
            ResetDefault();
            if (_Mode==enMode.AddNew)
            {
                
                LocalDrivingLicenseApp = new clsLocalDrivingLicenseApplications();
                return;
            }

            LocalDrivingLicenseApp = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_LocalDriverLicenceAppID);

            if(LocalDrivingLicenseApp==null)
            {
                MessageBox.Show("this Application is not exist");
                this.Close();
                return;
            }
            
                _PersonID = LocalDrivingLicenseApp._application.ApplicantPersonID;
                controlPersonalInformationWithFilter1.LoadPersonInfo(_PersonID);

                controlPersonalInformationWithFilter1.FilterEnabled = false;
                comboBoxLicenceClass.Enabled = true;
                buttonSave.Enabled = true;

                labelAppID.Text = LocalDrivingLicenseApp._LocalDrivingLicenseAppID.ToString();

                labelAppDate.Text = LocalDrivingLicenseApp._application.ApplicationDate.ToShortDateString();
                _AppDate = LocalDrivingLicenseApp._application.ApplicationDate;
                
                labelCreatedByUser.Text = clsDVLDSittings._CurrentUser._User.UserName;

                labelTitle.Text = "Update Local Driver Licence Application";
                this.Text = "Update Local Driver Licence Application";

                comboBoxLicenceClass.SelectedValue = LocalDrivingLicenseApp._LicenseClassID;

                
                

            
        }
        private void FormLocalDriverLicenceAddAndUpdate_Load(object sender, EventArgs e)
        {
           
            _LoadData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_PersonID < 0)
            {

                comboBoxLicenceClass.Enabled = false;
                buttonSave.Enabled = false;
                MessageBox.Show("to Add New Licence App,Choase Person");
                return;

            }
            else if(_PersonID> 0) {
            
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedIndex++;

                    comboBoxLicenceClass.Enabled = true;

                    buttonSave.Enabled = true;


                }
            }
        }

        private bool HandleAgeLicenseClass(int Age)
        {
            bool IsAvaliable = false;
            switch (comboBoxLicenceClass.SelectedIndex)
            {

                case 1:
                    {
                        IsAvaliable = (Age >= 18);
                        break;

                    }
                case 2:
                    {

                        IsAvaliable = (Age >= 21);
                        break;
                    }
                case 3:
                    {
                        IsAvaliable = (Age >= 21);
                        break;
                    }
                case 4:
                    {
                        IsAvaliable = (Age >= 21);
                        break;
                    }
                case 5:
                    {
                        IsAvaliable = (Age >= 21);
                        break;
                    }
                case 6:
                    {
                        IsAvaliable = (Age >= 21);
                        break;
                    }
                default:
                    {
                        IsAvaliable = false;
                        break;

                    }
            }
            return IsAvaliable;
        }

        private bool CalculateTheAge()
        {
            DateTime DateofBirth = clsPeople.Find(_PersonID)._Person._DateOfBirth;
            int AvaliableAge =clsLicenceClasses.Find((int)comboBoxLicenceClass.SelectedValue)._DTOLicenceClasses.MinimumAllowedAge;
            DateTime Today = DateTime.Now;
            if (DateTime.Compare(Today.AddYears(-AvaliableAge), DateofBirth) >0)
            {
                return true;
            }
            

            return false;

        }
        private void Save()
        {
            

            LocalDrivingLicenseApp._application.ApplicationStatus = DTOApplication.enApplicationStatus.New;
            LocalDrivingLicenseApp._application.ApplicationTypeID = DTOApplication.enAppType.NewLocalDrivingLicenseService;
           
            LocalDrivingLicenseApp._application.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;
            
            LocalDrivingLicenseApp._application.PaidFees = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.NewDrivingLicence)._AppFees;
            LocalDrivingLicenseApp._application.LastStatusDate = DateTime.Now;
            LocalDrivingLicenseApp._application.ApplicantPersonID = _PersonID;
            

           if(_Mode==enMode.AddNew)
            { LocalDrivingLicenseApp._application.ApplicationDate = DateTime.Now; }
            else if(_Mode==enMode.Update)
            { LocalDrivingLicenseApp._application.ApplicationDate = _AppDate; }
              
            
            LocalDrivingLicenseApp._LicenseClassID =(int) comboBoxLicenceClass.SelectedValue;

            if(!CalculateTheAge())
            {
                MessageBox.Show("Your Age is not match Licence Class Requiered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            if (_Mode==enMode.AddNew&&clsApplications.DosePersonHaveActiveAppForLicenseClass(_PersonID,DTOApplication.enAppType.NewLocalDrivingLicenseService,(int)comboBoxLicenceClass.SelectedValue))
            {
                MessageBox.Show("this Person have Already An Active Application", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }
            
            if (LocalDrivingLicenseApp.Save())
            {
                _Mode = enMode.Update;
                labelAppID.Text=LocalDrivingLicenseApp._LocalDrivingLicenseAppID.ToString();
                labelTitle.Text = "Update Local Driver Licence Application";
                this.Text = "Update Local Driver Licence Application";
                _LocalDriverLicenceAppID = LocalDrivingLicenseApp._LocalDrivingLicenseAppID;
                MessageBox.Show("Saved Done Local Driver Licence Application with ID " + LocalDrivingLicenseApp._LocalDrivingLicenseAppID+" App Id "+LocalDrivingLicenseApp._application.ApplicationID);


            }else
            {
                MessageBox.Show("Saved Failed");

            }
            


        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
            
            FormLocalDriverLicenceAddAndUpdate_Load(null, null);




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
