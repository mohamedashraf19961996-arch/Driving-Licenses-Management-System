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
    public partial class FormAddInterNationalLicense : Form
    {
        public FormAddInterNationalLicense()
        {
            InitializeComponent();
        }

        
        int _LicenseID;
        clsLicenses licenses;
        clsInternationLicenses internationLicenses;
        private void FormAddInterNationalLicense_Load(object sender, EventArgs e)
        {
            buttonIssue.Enabled = false;

            controlLicenseInfoWithFilter1.OnSelection += ControlLicenseInfoWithFilter1_OnSelection;
            linkLabelShowLicenseInfo.Enabled = false;
            linkLabelShowLicenseHistory.Enabled = false;
            
            
        }

        private void ControlLicenseInfoWithFilter1_OnSelection(int obj)
        {
            _LicenseID= obj;
            
            


            if(_LicenseID==-1)
            {
                return;
            }

            licenses = clsLicenses.getLicensebyLicenseID(_LicenseID);
            if (licenses.LicenseInfo.LicenseClassID!= (int)DTOLicenceClasses.enLicenceClassName.Ordinarydrivinglicense)
            {

                MessageBox.Show("You cant Issue International License For License Class not Ordinary License Class", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonIssue.Enabled = false;
                return;

            }

            if(!licenses.DoseLicenseIsActive())
            {
                MessageBox.Show("Error,this License is not Active,You cant Issued International License on it","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
buttonIssue.Enabled= false;
                return;

            }
            internationLicenses = clsInternationLicenses.FindByLocalDriverLicenseID(_LicenseID);

            if (internationLicenses != null && internationLicenses.internationlLicenses.IsActive == true)
            {
                MessageBox.Show("You Cant Issued international license for this License because it has One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonIssue.Enabled = false;
                return;

            }




            labelCreatedBy.Text = clsDVLDSittings._CurrentUser._User.UserName;
            labelIssueDate.Text = DateTime.Now.ToString();
            labelAppDate.Text = DateTime.Now.ToString();
            labelLocalLicenseID.Text = controlLicenseInfoWithFilter1.LicenseInfo.LicenseInfo.LicenseID.ToString();
            labelExpirationdate.Text = controlLicenseInfoWithFilter1.LicenseInfo.LicenseInfo.ExpirationDate.ToString();
            labelFees.Text = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.NewInternationalDrivingLicence)._AppFees.ToString();


            linkLabelShowLicenseHistory.Enabled = true;

            buttonIssue.Enabled = true;



        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
                
                internationLicenses = new clsInternationLicenses();
            
            internationLicenses.internationlLicenses.ExpirationDate = controlLicenseInfoWithFilter1.LicenseInfo.LicenseInfo.ExpirationDate;
            internationLicenses.internationlLicenses.DriverID = controlLicenseInfoWithFilter1.LicenseInfo.LicenseInfo.DriverID;
            internationLicenses.DriverInfo = clsDrivers.FindDriverByID(licenses.LicenseInfo.DriverID);
            internationLicenses.internationlLicenses.IssueDate = DateTime.Now;
            internationLicenses.internationlLicenses.IssuedUsingLocalLicenseID = licenses.LicenseInfo.LicenseID;
            internationLicenses.internationlLicenses.IsActive = true;
            internationLicenses.internationlLicenses.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;
            
            if(internationLicenses.Save())
            {
                labelAppID.Text = internationLicenses.internationlLicenses.ApplicationID.ToString();
                labelInternationalID.Text=internationLicenses.internationlLicenses.InternationalLicenseID.ToString();
                labelAppDate.Text=DateTime.Now.ToString();
                linkLabelShowLicenseInfo.Enabled = true;
                controlLicenseInfoWithFilter1.FilterEnabled = false;

                MessageBox.Show("international License Issued Succefully with ID" + internationLicenses.internationlLicenses.InternationalLicenseID);
buttonIssue.Enabled = false;


            }else
            {
                MessageBox.Show("Saved Failed");
                return;
            }

        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormInternationalLicenseInfo(internationLicenses.internationlLicenses.InternationalLicenseID);
            Form.ShowDialog();
        }

        private void linkLabelShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormLicenseHistory(licenses.DriverInfo.PersonInformation._Person._PersonID);
            Form.ShowDialog();
        }
    }
}
