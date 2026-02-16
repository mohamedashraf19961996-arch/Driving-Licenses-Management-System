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
    public partial class FormPeople : Form
    {

        private static DataTable _DtAllPeople;
        private static DataTable _Dtpeople; 
            public FormPeople()
        {
            InitializeComponent();
            _FillFilter();


        }

        private void _FillFilter()
        {

            comboBox1.Items.Add("None");
            comboBox1.Items.Add("First Name");
            comboBox1.Items.Add("Second Name");
            comboBox1.Items.Add("Third Name");
            comboBox1.Items.Add("Last Name");
            comboBox1.Items.Add("National No");
            comboBox1.Items.Add("Nationalty");
            comboBox1.Items.Add("Phone");
            comboBox1.Items.Add("Person ID");



        }

        private void ReFreshData()
        {
            _DtAllPeople = clsPeople.ListPeople();
            _Dtpeople = _DtAllPeople.DefaultView.ToTable(false, @"PersonID",
            "FirstName", "SecondName", "ThirdName", "LastName", "NationalNo", "Gendor", "DateOfBirth", "CountryName", "Phone");

            dataGridView1.DataSource= _Dtpeople;
            comboBox1.SelectedIndex = 0;
            labelRecords.Text = "#Records : " + _Dtpeople.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "First Name";
                dataGridView1.Columns[1].Width = 110;

                dataGridView1.Columns[2].HeaderText = "Second Name";
                dataGridView1.Columns[2].Width = 120;

                dataGridView1.Columns[3].HeaderText = "Third Name";
                dataGridView1.Columns[3].Width = 120;


                dataGridView1.Columns[4].HeaderText = "Last Name";
                dataGridView1.Columns[4].Width = 110;

                dataGridView1.Columns[5].HeaderText = "National  No";
                dataGridView1.Columns[5].Width = 70;

                dataGridView1.Columns[6].HeaderText = "Gender";
                dataGridView1.Columns[6].Width = 70;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 140;

                dataGridView1.Columns[8].HeaderText = "Country";
                dataGridView1.Columns[8].Width = 100;


                dataGridView1.Columns[9].HeaderText = "Phone Number";
                dataGridView1.Columns[9].Width = 110;




            }



        }


        private void _LoadDataSearch()
        {
            string FilterColumn = "";
            switch (comboBox1.Text)
            {

                case "First Name":
                    {
                        FilterColumn = "FirstName";

                        break;
                    }
                case "Second Name":
                    {
                        FilterColumn = "SecondName";

                        break;
                    }
                case "Third Name":
                    {
                        FilterColumn = "ThirdName";

                        break;
                    }
                case "Last Name":
                    {
                        FilterColumn = "LastName";

                        break;
                    }
                case "National No":
                    {
                        FilterColumn = "NationalNo";

                        break;
                    }
                case "Nationalty":
                    {

                        FilterColumn = "CountryName";


                        break;
                    }
                case "Phone":
                    {
                        FilterColumn = "Phone";

                        break;

                    }
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }

                default:
                    {

                        FilterColumn = "None";

                        break;
                    }
            }

            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {

                _Dtpeople.DefaultView.RowFilter = "";
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "PersonID")
            {
                if(int.TryParse(textBox1.Text, out int value))
                _Dtpeople.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn,value);
            }
            else
            {       _Dtpeople.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterColumn, textBox1.Text.Trim());
        }
            labelRecords.Text=dataGridView1.Rows.Count.ToString();

        }
        
        private void FormPeople_Load(object sender, EventArgs e)
        {
            ReFreshData();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _LoadDataSearch();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
                FormAddNewPerson Form=new FormAddNewPerson();
                 Form.ShowDialog();
            ReFreshData();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewPerson Form=new FormAddNewPerson();
            Form.ShowDialog();
            ReFreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewPerson Form = new FormAddNewPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            ReFreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonId = ((int)dataGridView1.CurrentRow.Cells[0].Value);
           if ( clsPeople.DeletePerson(PersonId))
            {
                ReFreshData();   
                MessageBox.Show($"Deleted Done Succefully for Person Id {PersonId}");
            }else
            {
                MessageBox.Show("Deleted Failed");
            }
        }

        private void callNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Feature will be here soon");

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Feature will be here soon");

        }

        private void showPersonDetailedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowPersonInformation2 Form = new FormShowPersonInformation2((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible=(comboBox1.Text!="None");

            if(textBox1.Visible)
            {
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}
