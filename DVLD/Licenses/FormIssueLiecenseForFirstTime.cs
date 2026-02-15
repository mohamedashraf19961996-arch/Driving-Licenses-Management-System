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
    public partial class FormIssueLiecenseForFirstTime : Form
    {
        public FormIssueLiecenseForFirstTime()
        {
            InitializeComponent();
        }

        public FormIssueLiecenseForFirstTime(int LocalDriverLicenseID)
        {
            InitializeComponent();
            
            _LocalDriverLicenseID = LocalDriverLicenseID;
        
        }

        
        int _LocalDriverLicenseID;
        clsLicenses License;
        clsDrivers Driver;
        clsLocalDrivingLicenseApplications LocalDrivingLicenseApplication;
        
        private bool HandleIsPersonHaveLicenseForLicenseClass()
        {
            if (clsLicenses.DoseDriverHaveLicenseOfLicenseClass(LocalDrivingLicenseApplication._application.ApplicationID, LocalDrivingLicenseApplication.licenceClass._DTOLicenceClasses.ClassNameID))
            {

                buttonSave.Enabled = false;
                MessageBox.Show("Driver Has Already a License for this License Class","Error");
                return false;
            }
            else return true;


        }

        
        private void LoadData()
        {
            this.Text = "Issue License For First Time";
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(_LocalDriverLicenseID);

            if(LocalDrivingLicenseApplication==null)
            {
                MessageBox.Show("Error,No Local Driving License Application", "Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            controlLocalDriverLicenseInformation1.LoadData(_LocalDriverLicenseID);
            if (!HandleIsPersonHaveLicenseForLicenseClass())
                return;


        }
        private void FormIssueLiecenseForFirstTime_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool UpdateStatus()
        {

            if (!LocalDrivingLicenseApplication.setComplete())
            {
                MessageBox.Show("there is an Error with Update Status");
                return false;
            }
            return true;

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Driver = clsDrivers.FindDriverByPersonID(LocalDrivingLicenseApplication._PersonInfo._Person._PersonID);
            if (Driver == null)
            {
                Driver = new clsDrivers();
                Driver.Driver.PersonID = LocalDrivingLicenseApplication._PersonInfo._Person._PersonID;
                Driver.Driver.UserID = clsDVLDSittings._CurrentUser._User.UserID;

                Driver.Driver.CreatedDate = DateTime.Now;

                if (!Driver.Save())
                {
                    MessageBox.Show("Error,Cant Save Driver ID in the System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            License = new clsLicenses();
            
            License.LicenseInfo.ApplicationID = LocalDrivingLicenseApplication._application.ApplicationID;
            License.LicenseInfo.DriverID = Driver.Driver.DriverID;
            License.LicenseInfo.LicenseClassID = LocalDrivingLicenseApplication._LicenseClassID;
            License.LicenseInfo.IssueDate= DateTime.Now;
            License.LicenseInfo.ExpirationDate = DateTime.Now.AddYears(LocalDrivingLicenseApplication.licenceClass._DTOLicenceClasses.DefaultValidityLength);
            License.LicenseInfo.Notes = richTextBox1.Text.Trim();
            License.LicenseInfo.PaidFees = LocalDrivingLicenseApplication.licenceClass._DTOLicenceClasses.ClassFees;
            License.LicenseInfo.IsActive = true;
            License.LicenseInfo.issueReason= DTOLicense.enIssueReason.FirstTime;
            License.LicenseInfo.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;

            if(License.Save())
            {
                MessageBox.Show("Congratulation,You Issue Your License With ID " + License.LicenseInfo.LicenseID, "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (!UpdateStatus())
                    return;
                buttonSave.Enabled = false;
                richTextBox1.Enabled= false;

            }else
            {
                MessageBox.Show("Saved Failed,Try Issue License Again");
            }



        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
