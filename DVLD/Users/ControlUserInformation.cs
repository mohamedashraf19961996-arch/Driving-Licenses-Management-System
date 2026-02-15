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
    public partial class ControlUserInformation : UserControl
    {
        public ControlUserInformation()
        {
            InitializeComponent();
        }

        clsUsers _User;
        int _UserID;
        public clsUsers UserInformation
        { get { return _User; } }






        public void LoadUserInfo(int UserID)
        {
            
            _UserID=UserID;
            _User = clsUsers.GetUserByUserID(_UserID);
            if (_User == null)
            {
                ResetDefaultControl();
                MessageBox.Show("No User with this User ID " + UserID);
                return;
            }
            else if (_User != null)
            {
                
                    LoadUsercontrolInformation();

                

            }
        }
        private void ResetDefaultControl()
        {
            labelUserID = default;
            labelUserName = default;
            labelIsActive = default;



        }
        private void LoadUsercontrolInformation()
        {
            
            
                labelUserID.Text = _User._User.UserID.ToString();
                labelUserName.Text = _User._User.UserName.ToString();
                if (_User._User.IsActive == true)
                {
                    labelIsActive.Text = "Yes";
                }
                else { labelIsActive.Text = "No"; }

                LoadPersonInformation(_User._User.PersonID);
            
           
        }
        private void LoadPersonInformation(int PersonID)
        {
            contolPersonalInformation1.LoadData(PersonID);

        }
        private void ControlUserInformation_Load(object sender, EventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
