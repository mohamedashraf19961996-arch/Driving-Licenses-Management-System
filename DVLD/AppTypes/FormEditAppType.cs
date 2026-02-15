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
    public partial class FormEditAppType : Form
    {
        public FormEditAppType()
        {
            InitializeComponent();
        }
        enum enMode { AddNew,Update}
        enMode _Mode=enMode.AddNew;
        int _AppID;
        clsApplicationTypes _AppType;
        public FormEditAppType(int AppID)
        {
            InitializeComponent();
            _AppID= AppID;
            _Mode = enMode.Update;

        }

        private void ResetDefault()
        {
            if (_Mode == enMode.Update)
            {
                _AppType = clsApplicationTypes.FindApptype((clsApplicationTypes.enAppType)_AppID);

                if (_AppType == null)
                {
                    MessageBox.Show("this App type is Not Found,Contact the Admin");
                    this.Close();
                    return;
                }
                labelAppID.Text = _AppType._AppID.ToString();
                textBoxAppName.Text = _AppType._AppName;
                textBoxAppFees.Text = _AppType._AppFees.ToString();
                this.Text = "Form Edit App type";
                label1.Text = "Edit App type";
            }
        }
        private void FormEditAppType_Load(object sender, EventArgs e)
        {
           
            ResetDefault(); 
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _AppType._AppName = textBoxAppName.Text.Trim();
            if(decimal.TryParse(textBoxAppFees.Text,out decimal value))
            {
                _AppType._AppFees = value;
            }else
            {
                MessageBox.Show("Enter Valid Number in App Fees");
                return;
            }


            if(_AppType.Save())
            {
                MessageBox.Show($"App type with ID {_AppType._AppID} Updated Succefully");
               

            }else
            {
                MessageBox.Show("Updated Failed");
            }


        }
    }
}
