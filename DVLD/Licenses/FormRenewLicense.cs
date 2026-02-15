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
    public partial class FormRenewLicense : Form
    {
        public FormRenewLicense()
        {
            InitializeComponent();
        }

        int _LicenseID;
        clsLicenses _License;
        int _NewLicenseID;
        private void ResetDefault()
        {
            labelAppDate.Text = DateTime.Now.ToShortDateString();
            labelAppFees.Text=clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.RenewDrivingLicence)._AppFees.ToString();
            labelisuueDate.Text=DateTime.Now.ToShortDateString();
            labelCreatedBy.Text = clsDVLDSittings._CurrentUser._User.UserName;
            richTextBox1.Text = "";
            linkLabelShowLicenseInfo.Enabled= false;
            controlLicenseInfoWithFilter1.OnSelection += ControlLicenseInfoWithFilter1_OnSelection;





        }
        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void FormRenewLicense_Load(object sender, EventArgs e)
        {
            ResetDefault();
        
        
        }

        private void ControlLicenseInfoWithFilter1_OnSelection(int obj)
        {
            _LicenseID = obj;

             _License = clsLicenses.getLicensebyLicenseID(_LicenseID);

            if (_License != null)
            {
                labelOldLicenseID.Text = _License.LicenseInfo.LicenseID.ToString();
                richTextBox1.Text = _License.LicenseInfo.Notes.Trim();

                if (_License.LicenseInfo.ExpirationDate > DateTime.Now)
                {
                    MessageBox.Show("You Cant Renew this License because its Experiation Date is still Avaliable", "Error");
                    buttonSave.Enabled = false;

                    return;



                }

                if(!_License.DoseLicenseIsActive())
                {
                    MessageBox.Show("this License is not Active,You Cant Renew It");
                    buttonSave.Enabled = false;

                    return;
                }

                buttonSave.Enabled = true;

            }
            else
                MessageBox.Show("this License is not Exist");



        }

        private void LoadDataForNewLicense()
        {
            
            _License = clsLicenses.getLicensebyLicenseID(_NewLicenseID);
            if (_License != null)
            {
                labelLicenseFess.Text = _License.LicenseInfo.PaidFees.ToString();
                labelRenewLicenseID.Text = _License.LicenseInfo.LicenseID.ToString();
                labelAppID.Text=_License.ApplicationInfo._application.ApplicationID.ToString();
                labelExperationDate.Text = _License.LicenseInfo.ExpirationDate.ToShortDateString();
                decimal Totalfees = _License.LicenseInfo.PaidFees + clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.RenewDrivingLicence)._AppFees;
                labeltotalFees.Text=Totalfees.ToString();


            }
            else
            {
                MessageBox.Show("there is a Mistake With Load New License Data");
            }


        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            int NewLicenseID = _License.RenewLicense(clsDVLDSittings._CurrentUser._User.UserID, richTextBox1.Text.Trim());
            
            _LicenseID= NewLicenseID;
           if (NewLicenseID!=-1)
            {
                MessageBox.Show("Your New License is issued with ID" + NewLicenseID);
                buttonSave.Enabled=false;
                _NewLicenseID= NewLicenseID;
                LoadDataForNewLicense();
                controlLicenseInfoWithFilter1.FilterEnabled = false;
                linkLabelShowLicenseInfo.Enabled = true;
            }else
            {
                MessageBox.Show("Issued New License Failed");
                return;
            }

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormShowLicenseInfo(_LicenseID);
            Form.ShowDialog();
        }
    }
}
