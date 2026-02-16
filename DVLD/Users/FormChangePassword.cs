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
    public partial class FormChangePassword : Form
    {
        public FormChangePassword(int UserId)
        {
            InitializeComponent();
            _UserId = UserId;
        }

        clsUsers _User;
        int _UserId;
        


        private void ChangePassword()
        {
            if (!_User.CompareHashPassword(textBoxCurrent.Text.Trim()))
            {
                MessageBox.Show("the Current Password is not match with Old Password");
                return;
            }

            if (textBoxNewPass.Text.Trim() == textBoxConfirmPass.Text.Trim())
            {
                _User._User.Password = textBoxNewPass.Text.Trim();
                if(_User.Save())
                {
                    MessageBox.Show("Updated Done Succefully");
                    this.Close();
                }else
                {
                    MessageBox.Show("Error,Updated Failed");
                    return;
                }


            }else
            {
                MessageBox.Show("Password is not Match with Confirm Password");
            }





        }

        private void ResetDefaultValue()
        {
            textBoxCurrent.Text = "";
            textBoxNewPass.Text = "";
            textBoxConfirmPass.Text = "";
            textBoxCurrent.Focus();
        }
        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            ResetDefaultValue();
            _User=clsUsers.GetUserByUserID(_UserId);
            if(_User==null)
            {
                MessageBox.Show("No User with this User Id " + _UserId);
                this.Close();
                return;
            }

            controlUserInformation1.LoadUserInfo(_UserId);

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            ChangePassword();



        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
