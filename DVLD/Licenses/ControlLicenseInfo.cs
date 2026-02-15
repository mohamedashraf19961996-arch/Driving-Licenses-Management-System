using Business_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ControlLicenseInfo : UserControl
    {
        public ControlLicenseInfo()
        {
            InitializeComponent();
        }

        private  int _LicenseID;
       
       private clsLicenses _License;
        public int LicenseID
        { get { return _LicenseID; } }

        public clsLicenses LicenseInfo
        {
            get { return _License; }
        }
        private void _LoadImage()
        {
            string ImagePath = _License.DriverInfo.PersonInformation._Person._ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pictureBox1.Load(ImagePath);

                }
                else
                { MessageBox.Show("Could Not Find this Image"); }


            }
            else return; 
        }


        
        public void LoadControlInfo(int LicenseID)
        {
            
            _LicenseID = LicenseID;

            _License = clsLicenses.getLicensebyLicenseID(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show("Error,No License With this ID" + _LicenseID, "Error");
                _LicenseID = -1;
                return;
            }

            labelClass.Text = _License.LicenseClassInfo._DTOLicenceClasses.ClassName;
            labelName.Text = _License.DriverInfo.PersonInformation._Person.FullName;
            labelNationalNo.Text = _License.DriverInfo.PersonInformation._Person._NationalNO;
            labelGender.Text = _License.DriverInfo.PersonInformation._Person._Gender.ToString();
            labelDateOfBirth.Text = _License.DriverInfo.PersonInformation._Person._DateOfBirth.ToShortDateString();
            labelDriverID.Text = _License.DriverInfo.Driver.DriverID.ToString();
            labelIssueDate.Text = _License.LicenseInfo.IssueDate.ToShortDateString();
            labelExPerationDate.Text = _License.LicenseInfo.ExpirationDate.ToShortDateString();
            labelLicenseID.Text = _License.LicenseInfo.LicenseID.ToString();
            labelNotes.Text = _License.LicenseInfo.Notes.ToString();
            labelIssueReason.Text = _License.LicenseInfo.issueReason.ToString();
            if (_License.LicenseInfo.IsActive == true)
            { labelIsActive.Text = "Yes"; }
            else { labelIsActive.Text = "No"; }
            _LoadImage();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ControlLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
