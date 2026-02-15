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
    public partial class FormReplacementForDamagedOrLost : Form
    {
        public FormReplacementForDamagedOrLost()
        {
            InitializeComponent();
        }

        private void ResetDefault()
        {

            controlLicenseInfoWithFilter1.OnSelection += ControlLicenseInfoWithFilter1_OnSelection; 
            radioButtonDamaged.Checked = true;
            labelAppDate.Text = DateTime.Now.ToString();
            labelCreatedBy.Text = clsDVLDSittings._CurrentUser._User.UserName;
            linkLabelShowLicenseInfo.Enabled = false;
            





        }
        int _LicenseID;
        clsLicenses _License;

        private void ControlLicenseInfoWithFilter1_OnSelection(int obj)
        {
            _LicenseID = obj;
            _License = clsLicenses.getLicensebyLicenseID(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Error,No License With this ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonIssue.Enabled = false;
                return;
            }
            labelOldLicenseID.Text = _License.LicenseInfo.LicenseID.ToString();
           
            


        }

        private void FormReplacementForDamagedOrLost_Load(object sender, EventArgs e)
        {
            ResetDefault();
            

        }

        private void buttonIssue_Click(object sender, EventArgs e)
        {
            if(_License==null)
            {
                MessageBox.Show("you must Choase License ID First");
                return;

            }

            if (!_License.DoseLicenseIsActive())
            {
                MessageBox.Show("Error,this License is not Active,You cant Do Any Proccess on it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonIssue.Enabled = false;
                return;

            }

            if(!_License.DoseLicenseExpierd())
            {
                MessageBox.Show("Error,this License is Expired,you Cant Replace it","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }


            if (radioButtonDamaged.Checked)
            {


                _LicenseID = _License.ReplacementForDamaged(clsDVLDSittings._CurrentUser._User.UserID);
                if (_LicenseID != -1)
                {
                    MessageBox.Show("Your New License is Issued with ID" + _LicenseID);


                }
                else
                {
                    buttonIssue.Enabled = false;
                    MessageBox.Show("Saved Failed");
                    return;
                }
            }
            else if (radioButtonLost.Checked)
            {


                _LicenseID = _License.ReplacementForLost(clsDVLDSittings._CurrentUser._User.UserID);
                if (_LicenseID != -1)
                {

                    MessageBox.Show("Your New License is Issued with ID" + _LicenseID);
                  }
                else
                {
                    buttonIssue.Enabled = false;
                    MessageBox.Show("Saved Failed");
                    return;
                }


            }
            buttonIssue.Enabled = false;
            labelAppID.Text = _License.ApplicationInfo._application.ApplicationID.ToString();
            labelReplacedLicenseID.Text = _License.LicenseInfo.LicenseID.ToString();
            groupBoxReplacement.Enabled = false;
            linkLabelShowLicenseInfo.Enabled = true;

            controlLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void linkLabelShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormShowLicenseInfo(_LicenseID);
            Form.ShowDialog();  
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButtonDamaged_CheckedChanged(object sender, EventArgs e)
        {
            labeltitle.Text = "Replacement for Damaged";
            this.Text = labeltitle.Text;

            labelAppFees.Text = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReplaceDamageDrivingLicence)._AppFees.ToString();

        }

        private void radioButtonLost_CheckedChanged(object sender, EventArgs e)
        {

            labeltitle.Text = "Replacement for Lost";
            this.Text = labeltitle.Text;
            labelAppFees.Text = clsApplicationTypes.FindApptype(clsApplicationTypes.enAppType.ReplaceLostDrivingLicence)._AppFees.ToString();


        }
    }
}
