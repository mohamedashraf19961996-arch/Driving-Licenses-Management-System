using Business_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ControlLicenseInfoWithFilter : UserControl
    {
        public ControlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        int _LicenseID;
        private bool _FilterInabled = true;
        public bool FilterEnabled
        {
            get { return _FilterInabled; }
            set
            {
                _FilterInabled = value;
                groupBox1.Enabled = _FilterInabled;

            }
        }

        public event Action<int> OnSelection;

        public int LicenseID { get { return controlLicenseInfo1.LicenseID; } }

        public clsLicenses LicenseInfo { get { return controlLicenseInfo1.LicenseInfo; } 
}
        protected virtual void OnLicense_Selection(int LicenseID)
        {
            Action<int> handler = OnSelection;

            if (handler != null)
            {

                handler(LicenseID);

            }
        }

        public void LoadInfo(int LicenseID)
        {
            textBox1.Text= LicenseID.ToString();
            controlLicenseInfo1.LoadControlInfo(LicenseID);
            _LicenseID = controlLicenseInfo1.LicenseID;
            if(OnSelection!=null&&FilterEnabled)
            {
                OnLicense_Selection(_LicenseID);

            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text,out int value))
            {
                LoadInfo(value);
            }





        }

        private void controlLicenseInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
