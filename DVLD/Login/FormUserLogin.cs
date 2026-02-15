using Business_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace DVLD
{
    public partial class FormUserLogin : Form
    {
        public FormUserLogin()
        {
            InitializeComponent();
            
        }
        string UserName = "", Password = "";
        private void ResetDefult()
        {
            textBoxUseLogin.Text = "";
            textBoxUserPassword.Text = "";
                
            clsUtils.RestoreLoginInfo(ref UserName,ref Password);
            if (UserName!=null&&Password!=null)
            {
                textBoxUseLogin.Text = UserName;
                textBoxUserPassword.Text = Password;
                checkBoxRemeberMe.Checked = true;
                buttonLogin.Focus(); }
            else 
            {
                textBoxUseLogin.Text = "";
                textBoxUserPassword.Text = "";
                checkBoxRemeberMe.Checked= false;
                textBoxUseLogin.Focus();
            }



        }


        private void SaveLoginInfoInTextFile()
        {
            
            if (checkBoxRemeberMe.Checked==true)
            {
              
                if(textBoxUseLogin.Text!=""&&textBoxUserPassword.Text!="")
                clsUtils.CopyLoginInfoToTextFile(textBoxUseLogin.Text.Trim(), textBoxUserPassword.Text.Trim());
                
            }
            else if (checkBoxRemeberMe.Checked==false)
            {
               

                clsUtils.CopyLoginInfoToTextFile("", "");

            }


        }
        private void textBoxUserPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string UserName = textBoxUseLogin.Text.Trim();
            string Password = textBoxUserPassword.Text.Trim();


            if (clsDVLDSittings.GetCurrentUser(UserName, Password))
            {
                if (clsDVLDSittings._CurrentUser._User.IsActive)
                {
                    clsUtils.AddLogingAsEventLog($"User {UserName} is Loging Now",EventLogEntryType.Information);
                    
                    SaveLoginInfoInTextFile();
                    this.Hide();
                    FormMainMenueScreen form = new FormMainMenueScreen(this);
                    form.ShowDialog();
                    clsUtils.AddLogingAsEventLog($"User {UserName} Signed out Now",EventLogEntryType.Information);
                    FormUserLogin_Load(null, null);


                }
                else
                {
                    clsUtils.AddLogingAsEventLog($"User With {UserName} failed to login", EventLogEntryType.Warning);
                    
                    textBoxUseLogin.Focus();
                    MessageBox.Show("this User is not Active,Contact Admin");
                    return;
                }

            }
            else
            {
                clsUtils.AddLogingAsEventLog($"User With {UserName} failed to login", EventLogEntryType.Warning);

                MessageBox.Show("User Name Or Password is Wrong,Enter Another One", "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }








        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxRemeberMe_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            ResetDefult();
        }
    }
}
