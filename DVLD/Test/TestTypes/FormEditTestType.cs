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
    public partial class FormEditTestType : Form
    {
        public FormEditTestType()
        {
            InitializeComponent();

        }
        int _TestID;
        clsTestTypes _Test;
        public FormEditTestType(int TestID)
        {
            InitializeComponent();

            _TestID = TestID;
        }
        private void ResetDefult()
        {
            _Test = clsTestTypes.Find((clsTestTypes.enTestTypeId)_TestID);

            if (_Test != null)
            {
                labelTestID.Text= _TestID.ToString();
                textBoxTitle.Text = _Test._TestTitle;
                textBoxFees.Text=_Test._TestFees.ToString();
                richTextBoxDesc.Text = _Test._TestDescription;

            }else
            {
                MessageBox.Show("this Test is not Found");
                this.Close();
            }


        }
        private void FormEditTestType_Load(object sender, EventArgs e)
        {
            ResetDefult();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _Test._TestTitle=textBoxTitle.Text.Trim();
            if(decimal.TryParse(textBoxFees.Text, out decimal value))
            {
                _Test._TestFees=value;
            }else
            {
                MessageBox.Show("Enter Valid Test Fees");
                return;
            }
            _Test._TestDescription=richTextBoxDesc.Text.Trim();

            if(_Test.Save())
            {
                MessageBox.Show("Save Done");
            }else
            {
                MessageBox.Show("Save Failed");
            }


        }
    }
}
