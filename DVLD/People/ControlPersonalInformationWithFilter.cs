using Business_Layer_DVLD;
using DVLD.People;
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
    public partial class ControlPersonalInformationWithFilter : UserControl
    {

        public event Action<int> OnPersonSelection;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelection;

            if(handler != null)
            {
                handler(PersonID);
            }


        }
        public ControlPersonalInformationWithFilter()
        {
            InitializeComponent();
        }

        bool _ShowAddNewPerson = true;

        public bool ShowAddNewPerson
        {
            get { return _ShowAddNewPerson; }
            set
            {
                _ShowAddNewPerson = value;
                buttonAddNewPerson.Visible = _ShowAddNewPerson;
            }
        }
        bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value; 
            groupBox1.Enabled = _FilterEnabled;
            }

        }

        int _PersonId=-1;
        public int PersonId
        {
            get { return contolPersonalInformation1.PersonID; }
        }

        public clsPeople _Person
        {
            get { return contolPersonalInformation1.PersonInformation; }
        }

        public void LoadPersonInfo(int PersonID)
        {
            comboBox1.SelectedIndex = 1;
            textBox1.Text=PersonID.ToString();
            GetPersonID();
        }
        private void FillComboBox()
        {
            comboBox1.Items.Add("PersonID");
            comboBox1.Items.Add("NationalNo");
        }

        private void GetPersonID()
        {
            if (int.TryParse(textBox1.Text, out int personID))
            { contolPersonalInformation1.LoadData(personID); }
            else
            {
                return;
            }
        }

        private void GetNationalNo()
        {
            contolPersonalInformation1.LoadData(textBox1.Text.Trim());

        }

        private void GetComboBoxChoice()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "PersonID":
                    {
                        GetPersonID();
                        break;
                    }
                case "NationalNo":
                    {
                        GetNationalNo(); break;
                    }
                default: { break; }



            }

            if (OnPersonSelection != null&&FilterEnabled)
            {
                OnPersonSelection(contolPersonalInformation1.PersonID);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void ControlPersonalInformationWithFilter_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            FillComboBox();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not Valide");
                return;
            }


            if(comboBox1!=null)
            {
                GetComboBoxChoice();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormAddNewPerson Form = new FormAddNewPerson(-1);
            Form.Databack += Form_Databack;
            Form.ShowDialog();
            
        }

        private void Form_Databack(object sender,clsPeople Person)
        {
            _PersonId = Person._Person._PersonID;
            contolPersonalInformation1.LoadData(_PersonId);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                buttonSearch.PerformClick();
            }

            if(comboBox1.Text=="PersonID")
            {
                e.Handled=!char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }



        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

            //if(comboBox1.SelectedItem.ToString()=="National No")
            //{
            //    return;
            //}


            //if(string.IsNullOrEmpty(textBox1.Text.Trim()))
            //{
            //    e.Cancel=true;
            //    errorProvider1.SetError(textBox1, "this Field is requierd");
            //}else
            //{
            //    errorProvider1.SetError(textBox1, null);
            //}



        }

        public void FilterFocus()
        {
            textBox1.Focus();   
        }

        private void contolPersonalInformation1_Load(object sender, EventArgs e)
        {

        }
    }
}
