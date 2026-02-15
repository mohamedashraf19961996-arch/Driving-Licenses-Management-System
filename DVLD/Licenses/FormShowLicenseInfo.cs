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
    public partial class FormShowLicenseInfo : Form
    {
        public FormShowLicenseInfo()
        {
            InitializeComponent();
        }

        public FormShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
        _LicenseID= LicenseID;
        }

        int _LicenseID;
        private void FormShowLicenseInfo_Load(object sender, EventArgs e)
        {
            controlLicenseInfo1.LoadControlInfo(_LicenseID);
        }

        private void controlLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
