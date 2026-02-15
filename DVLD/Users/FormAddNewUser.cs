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
    public partial class FormAddNewUser : Form
    {
        public FormAddNewUser()
        {
            InitializeComponent();
        
        }

        enum enMode { AddNew,Update}
        enMode _Mode = enMode.AddNew;
        int _UserID=-1;
        int _PersonID=-1;
        clsUsers _User;
        public FormAddNewUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = enMode.Update;
        }

      
        private void ResetDefault()
        {   if (_Mode == enMode.AddNew)
            {
                labelAddNewUser.Text = "Add New User";
                this.Text = "Add New User";
                _User= new clsUsers();
                buttonSave.Enabled = true;
                textBoxUserName.Enabled = false;
                textBoxPassword.Enabled = false;
                textBoxConfirmPassword.Enabled = false;
                checkBoxIsActive.Enabled = false;
                buttonSave.Enabled = false;

            }
            else
            {
                labelAddNewUser.Text = "Update User";
                this.Text = "Update User";
            }
            labelUserID.Text = "";
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
            textBoxConfirmPassword.Text = "";



        }
        private void LoadUserData()
        {
            
            if(_Mode==enMode.AddNew)
            {
                
                return;
            }
         

            _User = clsUsers.GetUserByUserID(_UserID);
            controlPersonalInformationWithFilter1.FilterEnabled = false;
            if (_User != null)
            {
                _PersonID = _User._User.PersonID;
                controlPersonalInformationWithFilter1.LoadPersonInfo(_PersonID);
                textBoxUserName.Text=_User._User.UserName;
                textBoxPassword.Text=_User._User.Password;
                textBoxConfirmPassword.Text = _User._User.Password;
                checkBoxIsActive.Checked = _User._User.IsActive;
                labelUserID.Text = _User._User.UserID.ToString();
                
            }else
            {
                MessageBox.Show("No User With this User ID");
                this.Close();
                return;
            }

        }
        private void FormAddNewUser_Load(object sender, EventArgs e)
        {
            controlPersonalInformationWithFilter1.OnPersonSelection += ControlPersonalInformationWithFilter1_OnPersonSelection;
            ResetDefault();
            LoadUserData();
        }

        private void ControlPersonalInformationWithFilter1_OnPersonSelection(int obj)
        {
            _PersonID= obj;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(_Mode==enMode.Update)
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    tabControl1.SelectedIndex++;
                    textBoxConfirmPassword.Enabled = true;
                    textBoxPassword.Enabled = true;
                    textBoxUserName.Enabled = true;
                    checkBoxIsActive.Enabled = true;
                    buttonSave.Enabled = true;

                }
                return;
            }

            if (_PersonID != -1)
            {
                if (clsUsers.IsUserExsistbyPersonID(_PersonID))
                {
                    MessageBox.Show("this Person is already User in the System");
                    
                    return;
                }else
                {
                    if (tabControl1.SelectedIndex == 0)
                    {
                        tabControl1.SelectedIndex++;
                        textBoxConfirmPassword.Enabled = true;
                        textBoxPassword.Enabled = true;
                        textBoxUserName.Enabled = true;
                        checkBoxIsActive.Enabled = true;
                        buttonSave.Enabled = true;

                    }
                }

            }
            
        }

        private void _SaveNewUser()
        {

            if (_Mode == enMode.AddNew)
            {
                if (_PersonID == -1)
                {
                    MessageBox.Show("Enter Valid Person Info", "Warrning", MessageBoxButtons.OK);
                    return;
                }
                else if (clsUsers.IsUserExsistbyPersonID((_PersonID)))
                {
                    MessageBox.Show("this Person is already User in the System");
                    return;
                }

                

            }
              _User._User.UserName = textBoxUserName.Text.Trim();
            
            if (textBoxPassword.Text.Trim() == textBoxConfirmPassword.Text.Trim())
            {
                _User._User.Password = textBoxPassword.Text.Trim();
            }

            _User._User.IsActive = (checkBoxIsActive.Checked);
            _User._User.PersonID= _PersonID;

            if(_User.Save())
            {
                _UserID = _User._User.UserID;
                MessageBox.Show("User Added Succefully with User ID " + _User._User.UserID);
                labelUserID.Text = _UserID.ToString();
                
                _Mode = enMode.Update;
            }else
            {
                MessageBox.Show("User Added Failed");
            }

        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (clsUsers.IsUserExistbyUserName(textBoxUserName.Text.Trim()))
            {
                MessageBox.Show("this User Name is already exist,Choese another one");
                return;
            }

            _SaveNewUser();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
