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
    public partial class FormUserInfo : Form
    {
        public FormUserInfo()
        {
            InitializeComponent();

        }
        int _UserID;
        public FormUserInfo(int UserID)
        {
            InitializeComponent();
           _UserID = UserID;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUserInfo_Load(object sender, EventArgs e)
        {
            controlUserInformation1.LoadUserInfo(_UserID);
            
        }
    }
}
