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
    public partial class FormShowPersonInformation2 : Form
    {
        public FormShowPersonInformation2()
        {
            InitializeComponent();
            
        }

        int _PersonId=-1;
        string _NationalNo="";
        public FormShowPersonInformation2(int PersonID)
        {
            InitializeComponent();

            _PersonId = PersonID;
        }

        public FormShowPersonInformation2(string NationalNo)
        {
            InitializeComponent();

            _NationalNo=NationalNo;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormShowPersonInformation2_Load(object sender, EventArgs e)
        {
            if(_PersonId!=-1)
            {
                contolPersonalInformation1.LoadData(_PersonId);
            }else if(_NationalNo!="")
            {
                contolPersonalInformation1.LoadData(_NationalNo);
            }
        }
    }
}
