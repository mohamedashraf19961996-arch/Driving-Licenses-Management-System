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
    public partial class FormLocalLicenseInformation : Form
    {
        public FormLocalLicenseInformation()
        {
            InitializeComponent();
        }

        public FormLocalLicenseInformation(int LocalLicenseId)
        {
            InitializeComponent();
            _LocaLicenseID = LocalLicenseId;
        }
        int _LocaLicenseID;
        private void FormLocalLicenseInformation_Load(object sender, EventArgs e)
        {
            controlLocalDriverLicenseInformation1.LoadData(_LocaLicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
