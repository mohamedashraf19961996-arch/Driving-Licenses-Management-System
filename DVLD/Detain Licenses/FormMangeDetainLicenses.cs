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
    public partial class FormMangeDetainLicenses : Form
    {
        public FormMangeDetainLicenses()
        {
            InitializeComponent();
            Fillcombobox();
        }
        private void Fillcombobox()
        {
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("Detain ID");
            comboBox1.Items.Add("Is Released");
            comboBox1.Items.Add("National No");
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Released Application ID");

            comboBoxIsReleased.Items.Add("All");
            comboBoxIsReleased.Items.Add("Yes");
            comboBoxIsReleased.Items.Add("No");




        }
        DataTable Dt;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Is Released")
            {
                comboBoxIsReleased.Visible = true;
                textBox1.Visible = false;
                comboBoxIsReleased.Focus();
                comboBoxIsReleased.SelectedIndex = 0;



            }
            else
            {
                textBox1.Visible = (comboBox1.Text != "None");
                comboBoxIsReleased.Visible = false;
                textBox1.Text = "";
                textBox1.Focus();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = "";
            switch (comboBox1.Text)
            {
                case "Detain ID":
                    {

                        FilterBy = "DetainID";
                        break;
                    }
                case "National No":
                    {

                        FilterBy = "NationalNo";

                        break;
                    }
                case "Name":
                    {

                        FilterBy = "FullName";

                        break;
                    }
                case "Released Application ID":
                    {

                        FilterBy = "ReleaseApplicationID";
                        break;
                    }
                default:
                    {
                        FilterBy = "None";
                        break;
                    }



            }

            if(FilterBy=="None"||textBox1.Text=="")
            {
                Dt.DefaultView.RowFilter = "";
                
                labelRecords.Text=dataGridView1.Rows.Count.ToString();
                return;
            }

            if(FilterBy== "ReleaseApplicationID"||FilterBy== "DetainID")
            {
                if (int.TryParse(textBox1.Text, out int value)) {
                    Dt.DefaultView.RowFilter = string.Format("[{0}]={1}",FilterBy, value);
                
                }
            }else if (FilterBy== "FullName"||FilterBy== "NationalNo")
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'",FilterBy ,textBox1.Text.Trim());

            }
            
            labelRecords.Text = dataGridView1.Rows.Count.ToString();



        }

        private void buttonDetain_Click(object sender, EventArgs e)
        {
            Form Form=new FormDetainLicenses();
            Form.ShowDialog();
        }

        private void buttonRelease_Click(object sender, EventArgs e)
        {
            Form Form = new FormReleaseDetainLicense();
            Form.ShowDialog();
        }

        private void FormMangeDetainLicenses_Load(object sender, EventArgs e)
        {
            Dt = clsDetainLicens.ListDetainLicense();
            dataGridView1.DataSource = Dt;
            labelRecords.Text=dataGridView1.Rows.Count.ToString();
            textBox1.Visible= false;
            comboBoxIsReleased.Visible = false;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "D.ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "L.ID";
                dataGridView1.Columns[1].Width = 70;

                dataGridView1.Columns[2].HeaderText = "D.Date";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Fine Fees";
                dataGridView1.Columns[3].Width = 70;

                dataGridView1.Columns[4].HeaderText = "Release Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Is Released";
                dataGridView1.Columns[5].Width = 70;

                dataGridView1.Columns[6].HeaderText = "Na.No";
                dataGridView1.Columns[6].Width = 70;

                dataGridView1.Columns[7].HeaderText = "Name";
                dataGridView1.Columns[7].Width = 180;

                dataGridView1.Columns[8].HeaderText = "R.App.ID";
                dataGridView1.Columns[8].Width = 70;

                


            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void comboBoxIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filterby = "";
            string FilterColumn = "IsReleased";

            switch (comboBoxIsReleased.Text)
            {

                case "Yes":
                    {

                        Filterby = "1";
                        break;
                    }
                case "No":
                    {
                        Filterby = "0";
                        break;
                    }
                default:
                    {
                        Filterby = "All";
                        break;
                    }

            }
            if (Filterby == "All")
            {
                Dt.DefaultView.RowFilter = "";

            }
            else
            {
                Dt.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, Filterby);

            }
            labelRecords.Text = dataGridView1.Rows.Count.ToString();

        }
    }
}
