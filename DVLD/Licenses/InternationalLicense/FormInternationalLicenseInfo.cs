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
    public partial class FormInternationalLicenseInfo : Form
    {
        public FormInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public FormInternationalLicenseInfo(int InternationalLicenseId)
        {
            InitializeComponent();

            _internationalLicenseId = InternationalLicenseId;
        
        }
        int _internationalLicenseId;
        private void FormInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            this.Text = "Show International License Information";
            controlInternationalLicenseInfo1.LoadData(_internationalLicenseId);
        }
    }
}
