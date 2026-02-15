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
    public partial class FormReleaseDetainLicense : Form
    {
        public FormReleaseDetainLicense()
        {
            InitializeComponent();
        }

        

        private void FormReleaseDetainLicense_Load(object sender, EventArgs e)
        {
            controlLicenseInfoWithFilter1.OnSelection += ControlLicenseInfoWithFilter1_OnSelection;
            linkLabelLicenseInfo.Enabled = false;
            linkLabelLicenseHistory.Enabled = false;
            buttonSave.Enabled = false;

        }

        int _LicenseID;
        clsDetainLicens detainLicens;
        private void ControlLicenseInfoWithFilter1_OnSelection(int obj)
        {
            _LicenseID = obj;
            

            detainLicens=clsDetainLicens.FindbyLicenseID(_LicenseID);
            if (detainLicens == null)
            {
                MessageBox.Show("this License is not Detain,Choase Another one", "Error");
                buttonSave.Enabled = false;
                return;

            }
            if (detainLicens._DetainLicenseInfo.IsReleased == true)
            {
                MessageBox.Show("this License is Released,You Cant Release it Again", "Error");
                buttonSave.Enabled = false;
                return;

            }
            linkLabelLicenseInfo.Enabled = true;
            linkLabelLicenseHistory.Enabled = true;
            labelDetainDate.Text = detainLicens._DetainLicenseInfo.DetainDate.ToString();
            labelDetainID.Text=detainLicens._DetainLicenseInfo.DetainID.ToString();
            labelFineFees.Text=detainLicens._DetainLicenseInfo.FineFees.ToString();
            labelUserID.Text = clsDVLDSittings._CurrentUser._User.UserName;
            labelAppFees.Text = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReleaseDetainDrivingLicence)._AppFees.ToString();
            labelLicenseID.Text=detainLicens._DetainLicenseInfo.LicenseID.ToString();
            decimal TotalFees = detainLicens._DetainLicenseInfo.FineFees + clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReleaseDetainDrivingLicence)._AppFees;
            labelTotalFees.Text=TotalFees.ToString();


            buttonSave.Enabled = true;


        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You sure You Want to Release this License","Stop",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }


            detainLicens._DetainLicenseInfo.ReleaseDate= DateTime.Now;
            detainLicens._DetainLicenseInfo.ReleasedbyUserID = clsDVLDSittings._CurrentUser._User.UserID;
            if(detainLicens.ReleaseLicense(clsDVLDSittings._CurrentUser._User.UserID))
            {

                MessageBox.Show("Released Done Succefully");
                labelAppID.Text=detainLicens._DetainLicenseInfo.ReleaseAppId.ToString();
                buttonSave.Enabled = false;
                controlLicenseInfoWithFilter1.FilterEnabled = false;
                linkLabelLicenseHistory.Enabled = true;
                linkLabelLicenseInfo.Enabled= true;
            }else
            {
                MessageBox.Show("Released Failed");
                return;
            }







        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormShowLicenseInfo(_LicenseID);
            Form.ShowDialog();
        }

        private void linkLabelLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormLicenseHistory(clsLicenses.getLicensebyLicenseID(_LicenseID).DriverInfo.PersonInformation._Person._PersonID);
            Form.ShowDialog();
        }
    }
}
