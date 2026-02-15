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
    public partial class FormDetainLicenses : Form
    {
        public FormDetainLicenses()
        {
            InitializeComponent();
        }
        int _LicenseID;
        clsDetainLicens DetainLicense;
        private void FormDetainLicenses_Load(object sender, EventArgs e)
        {
            controlLicenseInfoWithFilter1.OnSelection += ControlLicenseInfoWithFilter1_OnSelection;
            labelCreatedBy.Text = clsDVLDSittings._CurrentUser._User.UserID.ToString(); 
            labelDetainDate.Text= DateTime.Now.ToString();
            linkLabelLicenseInfo.Enabled = false;
            linkLabelLicenseHistory.Enabled = false;
            buttonSave.Enabled = false;
        }


        private void ControlLicenseInfoWithFilter1_OnSelection(int obj)
        {
            _LicenseID = obj;
            labelLicenseID.Text= _LicenseID.ToString();
            DetainLicense = clsDetainLicens.FindbyLicenseID(_LicenseID);
           if(_LicenseID==-1)
            {

                return;
            }
            
            
            if(DetainLicense !=null&& DetainLicense._DetainLicenseInfo.IsReleased==false)
            {
                MessageBox.Show("this License is Already Detained,You Cant Detaind it");
                buttonSave.Enabled = false;
                
                return;

            }
            if(!clsLicenses.DoseLicenseIsActive(_LicenseID))
            {
                MessageBox.Show("this license is not active You cant Detain it");
                buttonSave.Enabled = false;

                return;


            }

            DetainLicense = null;
            linkLabelLicenseInfo.Enabled = true;
            linkLabelLicenseHistory.Enabled = true;
            textBox1.Focus();
            buttonSave.Enabled = true;
            

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DetainLicense = new clsDetainLicens();

            DetainLicense._DetainLicenseInfo.DetainDate = DateTime.Now;
            DetainLicense._DetainLicenseInfo.CreatedByUserID = clsDVLDSittings._CurrentUser._User.UserID;
            DetainLicense._DetainLicenseInfo.IsReleased = false;
            DetainLicense._DetainLicenseInfo.LicenseID=_LicenseID;
            if(int.TryParse(textBox1.Text, out int FineFees))
            {
                DetainLicense._DetainLicenseInfo.FineFees= FineFees;
            }else
            {
                MessageBox.Show("You must enter a Valid Fine Fees", "Error");
                return;
            }

            if(DetainLicense.Save())
            {

                labelDetainID.Text = DetainLicense._DetainLicenseInfo.DetainID.ToString();
                MessageBox.Show("Your Data is Saved Succefully With ID " + DetainLicense._DetainLicenseInfo.DetainID);
                buttonSave.Enabled = false;
                controlLicenseInfoWithFilter1.FilterEnabled = false;

            }else
            {
                MessageBox.Show("Error,Your Saved Is Failed,try Again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }





        }

        private void linkLabelLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form =new FormShowLicenseInfo(_LicenseID);
            Form.ShowDialog();
        }

        private void linkLabelLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form Form=new FormLicenseHistory(clsLicenses.getLicensebyLicenseID(_LicenseID).DriverInfo.Driver.PersonID);
            Form.ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
