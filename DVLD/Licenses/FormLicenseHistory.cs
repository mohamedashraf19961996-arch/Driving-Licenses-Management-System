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
    public partial class FormLicenseHistory : Form
    {
        public FormLicenseHistory()
        {
            InitializeComponent();
        }

        public FormLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID= PersonID;
        }
        int _PersonID=-1;
        private void FormLicenseHistory_Load(object sender, EventArgs e)
        {
            
                controlLicenseHistoryInfo1.LoadData(_PersonID);
            

        }

        private void controlLicenseHistoryInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
