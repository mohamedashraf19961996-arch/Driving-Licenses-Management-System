using Business_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class FormAddNewPerson : Form
    {
        public FormAddNewPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }


        public FormAddNewPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }
        int _PersonID;
        clsPeople _Person;
        enum enMode { AddNew,Update}
        enMode _Mode = enMode.AddNew;

        public delegate void DataBackDataHandler(object sender, clsPeople Person);
        public event DataBackDataHandler Databack;
        private bool _HandleImage()
        {
            if(_Person._Person._ImagePath!=pictureBox1.ImageLocation)
            {
                if(_Person._Person._ImagePath!=null)
                {

                    try
                    {

                        File.Delete(_Person._Person._ImagePath);

                    }catch
                    {
                       
                    }

                }

                if (pictureBox1.ImageLocation != null)
                {
                    string SourceImageFile=pictureBox1.ImageLocation.ToString();

                    if (clsUtils.CopyImagesToProjectImagesFile(ref SourceImageFile))
                    {
                        pictureBox1.ImageLocation = SourceImageFile;
                        return true;
                    }else
                    {
                        MessageBox.Show("Error Copying Image");
                        return false;
                    }
                    
                }
                

            }
            return true;




        }
        private void _AddNewPerson()
        {
            
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Field are not Valide");

                return;
            }

            if(!_HandleImage())
            {
                return ;
            }


            _Person._Person._FirstName = textBoxFirstName.Text.Trim();
            _Person._Person._SecondName = textBoxSecondName.Text.Trim();
            _Person._Person._ThirdName = textBoxThirdName.Text.Trim();
            _Person._Person._ForthName = textBoxLastName.Text.Trim();
            _Person._Person._Email = textBoxEmail.Text.Trim();
            _Person._Person._PhoneNumber = textBoxPhone.Text.Trim();
            _Person._Person._Address = textBoxAddress.Text.Trim();  
            _Person._Person._NationalNO = textBoxNationalNo.Text.Trim();
            _Person._Person._NationalCountryID =(int) comboBoxCountry.SelectedValue;
            if (radioButtonMale.Checked == true)
            { _Person._Person._Gender = DTOPeople.enGender.Male;
            }else if (radioButtonFemale.Checked==true)
            {
                _Person._Person._Gender = 0;
            }
            _Person._Person._DateOfBirth = dateTimePickerDateOfBirth.Value;
            if (pictureBox1.ImageLocation != null)
            {
                _Person._Person._ImagePath = pictureBox1.ImageLocation.ToString();
            }
            else _Person._Person._ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Added Done Succefully with Person ID" + _Person._Person._PersonID);
                _Mode = enMode.Update;
                labelPersonID.Text = _Person._Person._PersonID.ToString();
                label1.Text = "Edit Person";
                Databack?.Invoke(this, _Person);
            }
            else
            {
                MessageBox.Show("Added Failed");
            }


        }
        private void _FillComboBoxCountry()
        {
            comboBoxCountry.DataSource = clsCountries.ListCountries();
            comboBoxCountry.DisplayMember = "CountryName";
            comboBoxCountry.ValueMember = "CountryID";
        }

        private void ResetDefaultValue()
        {
            _FillComboBoxCountry();
            textBoxFirstName.Text = "";
            textBoxSecondName.Text = "";
            textBoxThirdName.Text = "";
            textBoxLastName.Text = "";
            textBoxNationalNo.Text = "";
            textBoxPhone.Text =  "";
            textBoxAddress.Text = "";
            textBoxEmail.Text = "";
            dateTimePickerDateOfBirth.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePickerDateOfBirth.MinDate = DateTime.Today.AddYears(-100);
            dateTimePickerDateOfBirth.Value = dateTimePickerDateOfBirth.MaxDate;
            radioButtonMale.Checked = true;
            comboBoxCountry.SelectedValue = 90;
            labelPersonID.Text = "D:T";
            pictureBox1.ImageLocation = null;
            linkLabelRemoveImage.Visible= false;

            if (_Mode == enMode.AddNew)
            {
                label1.Text = "Add New Person";
            }else if (_Mode==enMode.Update)
            {
                label1.Text = "Edit Person";
            }


        }
        private void _LoadData()
        {


           
            labelPersonID.Text=_Person._Person._PersonID.ToString();
            textBoxFirstName.Text = _Person._Person._FirstName;
            textBoxSecondName.Text= _Person._Person._SecondName;
            textBoxThirdName.Text = _Person._Person._ThirdName;
            textBoxLastName.Text = _Person._Person._ForthName;
            textBoxNationalNo.Text = _Person._Person._NationalNO;
            textBoxPhone.Text = _Person._Person._PhoneNumber;
            textBoxAddress.Text= _Person._Person._Address;
            textBoxEmail.Text= _Person._Person._Email;
            dateTimePickerDateOfBirth.Value = _Person._Person._DateOfBirth;
            if(_Person._Person._Gender==DTOPeople.enGender.Male)
            {
                radioButtonMale.Checked = true;
            }else radioButtonFemale.Checked = true;
            comboBoxCountry.SelectedValue = _Person._Person._NationalCountryID;
            if (_Person._Person._ImagePath != "")
            {
                pictureBox1.ImageLocation = _Person._Person._ImagePath;
                linkLabelRemoveImage.Visible = true;

            }
            label1.Text = "Edit Person";

        }
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string ImagePath= openFileDialog.FileName;
                pictureBox1.ImageLocation=ImagePath;
                linkLabelRemoveImage.Visible = true;
            }
        }
        private void FormAddNewPerson_Load(object sender, EventArgs e)
        {
            ResetDefaultValue();

            if(_Mode==enMode.AddNew)
            {
                _Person=new clsPeople();
                return;
            }
            _Person = clsPeople.Find(_PersonID);
            if (_Person != null)
            {
                _LoadData();
            }else
            {
                MessageBox.Show("this Person is Not Found");
                this.Close();
                return;
            }
        }


        private void linkLabelRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            linkLabelRemoveImage.Visible = false;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }
        
        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            
            TextBox Temb = (TextBox)sender;
           if(string.IsNullOrEmpty(Temb.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temb, "This Field is Reqiuerd");
            }else
            {
                errorProvider1.SetError(Temb, null);
            }

        }

        private void textBoxNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if(_Mode==enMode.Update)
            {
                return;
            }


            if (clsValidation.ValdiateNationalNo(textBoxNationalNo.Text.Trim()))
            {
                e.Cancel=true;
                errorProvider1.SetError(textBoxNationalNo, "this National Number is exsit");

            }else
            {
                errorProvider1.SetError (textBoxNationalNo, null);
            }

        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.ValidateEmail(textBoxEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBoxEmail, "Enter a valid Email");


            }
            else { errorProvider1.SetError(textBoxEmail, null); }
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
