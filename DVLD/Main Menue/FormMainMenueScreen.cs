using Business_Layer_DVLD;
using DVLD.Licenses.InternationalLicense;
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
    public partial class FormMainMenueScreen : Form
    {
        Form _Form;
        public FormMainMenueScreen(FormUserLogin Form)
        {
            InitializeComponent();
            _Form = Form;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItemPeople_Click(object sender, EventArgs e)
        {
            FormPeople form=new FormPeople();
          
            form.ShowDialog();
        }

        private void toolStripMenuItemUsers_Click(object sender, EventArgs e)
        {
            FormUsers form=new FormUsers();
       
            form.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDVLDSittings._CurrentUser = null;
            
            _Form.Show();
            this.Close();
            
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form=new FormUserInfo(clsDVLDSittings._CurrentUser._User.UserID);
            form.ShowDialog();


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormChangePassword(clsDVLDSittings._CurrentUser._User.UserID);
            Form.ShowDialog();
        }

        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new FormAppTypes();
            form.ShowDialog();
        }

        private void localLicenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormLocalDriverLicenceAddAndUpdate();
            Form.ShowDialog();
        }

        private void localDriverLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormLocalDriverLicense();
            Form.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormRenewLicense();
            Form.ShowDialog();
        }

        private void replacementForLostOrDamagedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormReplacementForDamagedOrLost();
            Form.ShowDialog();
        }

        private void detainLicesenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormDetainLicenses();
            Form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormDrivers();
            Form.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormReleaseDetainLicense();
            Form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormAddInterNationalLicense();
            Form.ShowDialog();
        }

        private void internationalLicensesApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormInterNationalLicensesList();
            Form.ShowDialog();
        }

        private void testTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form =new FormTestTypes();
            Form.ShowDialog();
        }
    }
}
