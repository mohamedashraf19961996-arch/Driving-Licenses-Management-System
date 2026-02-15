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
    public partial class FormDrivers : Form
    {
        public FormDrivers()
        {
            InitializeComponent();
            FillComboBox();
        }

        
        DataTable dtDrivers;

        private void FillComboBox()
        {

            comboBox1.Items.Add("None");
            comboBox1.Items.Add("PersonID");
            comboBox1.Items.Add("DriverID");
            comboBox1.Items.Add("National No");
            comboBox1.Items.Add("Name");





        }
        private void ResetDefault()
        {
            comboBox1.SelectedIndex = 0;
            dtDrivers = clsDrivers.ListDrivers();
            dataGridView1.DataSource = dtDrivers;
            labelRecods.Text=dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width= 70;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 70;

                dataGridView1.Columns[2].HeaderText = "National No";
                dataGridView1.Columns[2].Width = 70;

                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 180;

                dataGridView1.Columns[4].HeaderText = "Created Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Number Of Active License";
                dataGridView1.Columns[5].Width = 70;



            }
        }
        private void FormDrivers_Load(object sender, EventArgs e)
        {
            ResetDefault();
        }

        private void ChoaseComboBox()
        {
            string Filterby;
            switch(comboBox1.Text)
            {

                case "PersonID":
                    {

                        Filterby = "PersonID";
                        break;


                    }
                case "DriverID":
                    {
                        Filterby = "DriverID";
                        break;


                    }
                case "National No":
                    {

                        Filterby = "NationalNo";
                        break;
                    }
                case "Name":
                    {
                        Filterby = "FullName";
                        break;
                    }
                default:
                    {
                        Filterby = "None";
                        break;
                    }









            }

            if(Filterby=="None"||textBox1.Text=="")
            {
                dtDrivers.DefaultView.RowFilter="";
                labelRecods.Text=dtDrivers.Rows.Count.ToString();
                return;
            }

            if(Filterby=="PersonID"||Filterby=="DriverID")
            {
                if(int.TryParse(textBox1.Text, out int value))
                {
                    dtDrivers.DefaultView.RowFilter=string.Format("[{0}]={1}",Filterby,value);
                }


            }else
            {
                dtDrivers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", Filterby, textBox1.Text);
            }

            labelRecods.Text = dataGridView1.Rows.Count.ToString();






        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = (comboBox1.Text != "None");
            if (textBox1.Visible)
            {
                textBox1.Text = "";
                textBox1.Focus();
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ChoaseComboBox();
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormShowPersonInformation2((int)dataGridView1.CurrentRow.Cells[1].Value);
            Form.ShowDialog();
            FormDrivers_Load(null, null);
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormLicenseHistory((int)dataGridView1.CurrentRow.Cells[1].Value);
            Form.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form Form = new FormLicenseHistory();
            Form.ShowDialog();
        }
    }
}
