using Business_Layer_DVLD;
using DVLD.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class contolPersonalInformation : UserControl
    {
        public contolPersonalInformation()
        {
            InitializeComponent();
        }

        clsPeople _Person;
        int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPeople PersonInformation
        {
            get { return _Person; }
        }

        public void LoadData(int PersonID)
        {
            _Person = null;
            _Person = clsPeople.Find(PersonID);
            if (_Person != null)
            {
                LoadControlInformation();
                return;
            }else
            {
                ResetDefault();
                MessageBox.Show("No person Information with this Person ID" + PersonID);
                
                return;
            }

        }
        public void LoadData(string NationalNo)
        {
            _Person = null;
            _Person = clsPeople.Find(NationalNo);
            if (_Person != null)
            {
                LoadControlInformation();
                
                return;
            }else
            {
                ResetDefault();
                MessageBox.Show("No person Information with this NationalNo" + NationalNo);
                
                return;
            }

        }
        private void LoadControlInformation()
        {


            linkLabel1.Visible= true;
            _PersonID = _Person._Person._PersonID;
            labelUserID.Text = _Person._Person._PersonID.ToString();
            labelName.Text = _Person._Person._FirstName + " " + _Person._Person._SecondName
                + " " + _Person._Person._ThirdName + " " + _Person._Person._ForthName;
            labelNationalNo.Text = _Person._Person._NationalNO;
            labelAddress.Text = _Person._Person._Address;
            labelPhone.Text = _Person._Person._PhoneNumber;
            labelDateOfBirth.Text= _Person._Person._DateOfBirth.ToString();
            labelEmail.Text = _Person._Person._Email;
            int CountryID = _Person._Person._NationalCountryID;
            labelCountry.Text=clsCountries.FindCountry(CountryID)._CountryName;
            
                labelGender.Text = _Person._Person._Gender.ToString();
            
            LoadPersonImage();
        }

        private void ResetDefault()
        {
            labelName.Text = "[???]";
            labelNationalNo.Text = "[???]";
            labelAddress.Text = "[???]";
            labelPhone.Text = "[???]";
            labelDateOfBirth.Text = "[???]";
            labelEmail.Text = "[???]";
            labelCountry.Text = "[???]";
            labelGender.Text = "[???]";
            pictureBox1.ImageLocation = null;
            linkLabel1.Visible= false;
            labelUserID.Text= "[???]";
            linkLabel1.Visible = false;



        }

        private void LoadPersonImage()
        {
            string ImagePath = _Person._Person._ImagePath;

            if (ImagePath!="")
            {
                if (File.Exists(ImagePath))
                {
                    pictureBox1.ImageLocation = ImagePath;
                }
                else
                { MessageBox.Show("Could not Find this Image Path" + ImagePath); }
            }



        }



        private void contolPersonalInformation_Load(object sender, EventArgs e)
        {
            ResetDefault();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddNewPerson Form=new FormAddNewPerson(PersonID);

            Form.ShowDialog();
             
          
            LoadData(PersonID);
        }
    }
}
