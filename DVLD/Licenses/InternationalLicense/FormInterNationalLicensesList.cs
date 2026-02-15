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

namespace DVLD.Licenses.InternationalLicense
{
    public partial class FormInterNationalLicensesList : Form
    {
        public FormInterNationalLicensesList()
        {
            InitializeComponent();
            FillComboBox();
        }

        DataTable DT;
        private void FillComboBox()
        {
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("International License ID");
            comboBox1.Items.Add("Application ID");
            comboBox1.Items.Add("Local Driver License ID");
            comboBox1.Items.Add("Name");
            comboBox1.Items.Add("Is Active");

            comboBoxIsActive.Items.Add("All");
            comboBoxIsActive.Items.Add("Yes");
            comboBoxIsActive.Items.Add("No");




        }
        private void FormInterNationalLicensesList_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            DT = clsInternationLicenses.ListInternationalLicense();
            dataGridView1.DataSource = DT;
            labelRecords.Text=dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "International License ID";
                dataGridView1.Columns[0].Width = 60;
                
                dataGridView1.Columns[1].HeaderText = "Application ID";
                dataGridView1.Columns[1].Width = 60;

                dataGridView1.Columns[2].HeaderText = "Local License ID";
                dataGridView1.Columns[2].Width = 60;

                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 180;

                dataGridView1.Columns[4].HeaderText = "Issue Date";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "Expiration Date";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "Is Active";
                dataGridView1.Columns[6].Width = 60;

                

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = "";
            switch(comboBox1.Text)
            {
                case "International License ID":
                    {
                        FilterBy = "InternationalLicenseID";

                        break;
                    }
                case "Application ID":
                    {


                        FilterBy = "ApplicationID";

                        break;

                    }
                case "Local Driver License ID":
                    {


                        FilterBy = "IssuedUsingLocalLicenseID";

                        break;

                    }
                case "Name":
                    {


                        FilterBy = "FullName";

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
                DT.DefaultView.RowFilter = "";
                labelRecords.Text=dataGridView1.Rows.Count.ToString();
                return;
            }

            if(FilterBy=="FullName")
            {
                DT.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", FilterBy, textBox1.Text.Trim());

            }else
            {
                if (int.TryParse(textBox1.Text, out int value)) {
                    DT.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterBy,value);
                
                }


            }
            labelRecords.Text = dataGridView1.Rows.Count.ToString();    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Is Active")
            {
                textBox1.Visible = false;
                comboBoxIsActive.Visible = true;
                comboBoxIsActive.Focus();
                comboBoxIsActive.SelectedIndex = 0;


            }else
            {

                textBox1.Visible = (comboBox1.Text != "None");
                comboBoxIsActive.Visible = false;
                textBox1.Focus();
                textBox1.Text = "";
            }
        }

        private void comboBoxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Filterby = "";
            switch (comboBoxIsActive.Text)
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

            if(Filterby=="All")
            {
                DT.DefaultView.RowFilter = "";
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
                
                return;
            }else
            {
                DT.DefaultView.RowFilter = string.Format("[{0}]={1}", "IsActive", Filterby);
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form =new FormAddInterNationalLicense();
            Form.ShowDialog();
        }

        private void showLicenseDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormInternationalLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
        }

        private void showLicensesHsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Form Form = new FormLicenseHistory(clsInternationLicenses.Find(InternationalLicenseID).DriverInfo.PersonInformation._Person._PersonID);
            Form.ShowDialog(); 
        }

        private void showPeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dataGridView1.CurrentRow.Cells[0].Value;

            Form Form = new FormShowPersonInformation2(clsInternationLicenses.Find(InternationalLicenseID).DriverInfo.PersonInformation._Person._PersonID);
            Form.ShowDialog();

        }
    }
}
