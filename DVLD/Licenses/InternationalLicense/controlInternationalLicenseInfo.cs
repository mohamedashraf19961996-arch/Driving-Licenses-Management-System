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
    public partial class controlInternationalLicenseInfo : UserControl
    {
        public controlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        int _InternationalLicenseID;
        public int InterationalLicenseID
        {
            get { return _InternationalLicenseID; }


        }

        clsInternationLicenses _internationLicenses;

        public clsInternationLicenses internationLicenses
        {
            get { return _internationLicenses; }
        }

        public void LoadData(int iternationalLicenseID)
        {
            _InternationalLicenseID=iternationalLicenseID;
            _internationLicenses = clsInternationLicenses.Find(_InternationalLicenseID);

            if (internationLicenses == null)
            {
                MessageBox.Show("No International License With this ID " + _InternationalLicenseID);
                return;

            }

            labelAppID.Text = _internationLicenses.internationlLicenses.ApplicationID.ToString();
            labelDateOFBirth.Text = _internationLicenses.DriverInfo.PersonInformation._Person._DateOfBirth.ToShortDateString();
            labelDriverID.Text=_internationLicenses.internationlLicenses.DriverID.ToString();
            labelExpirationDate.Text = _internationLicenses.internationlLicenses.ExpirationDate.ToShortDateString();
            labelGender.Text = _internationLicenses.DriverInfo.PersonInformation._Person._Gender.ToString();
            labelIntNationalID.Text=_internationLicenses.internationlLicenses.InternationalLicenseID.ToString();
            if (_internationLicenses.internationlLicenses.IsActive)
            {
                labelIsActive.Text = "Yes";

            }
            else labelIsActive.Text = "No";

            labelIssueDate.Text = _internationLicenses.internationlLicenses.IssueDate.ToShortDateString();
            labelLicenseID.Text = _internationLicenses.internationlLicenses.IssuedUsingLocalLicenseID.ToString();
            labelName.Text = _internationLicenses.DriverInfo.PersonInformation._Person.FullName;
            labelNationalityNo.Text = _internationLicenses.DriverInfo.PersonInformation._Person._NationalNO;



        }
        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void controlInternationalLicenseInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
