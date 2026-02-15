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
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
            FillFilterComboBox();


        }

        private static DataTable DTAllUsers;


        private void RefreshData()
        {
            DTAllUsers = clsUsers.ListUsers();
            dataGridView1.DataSource = DTAllUsers;
            labelRecords.Text = DTAllUsers.Rows.Count.ToString();
            comboBox1.SelectedIndex = 0;


            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "User ID";
                dataGridView1.Columns[0].Width = 90;

                dataGridView1.Columns[1].HeaderText = "Person ID";
                dataGridView1.Columns[1].Width = 90;

                dataGridView1.Columns[2].HeaderText = "User Name";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "Name";
                dataGridView1.Columns[3].Width = 200;

                dataGridView1.Columns[4].HeaderText = "Password";
                dataGridView1.Columns[4].Width = 120;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 120;

            }



        }

        private void FillFilterComboBox()
        {
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("User ID");
            comboBox1.Items.Add("Full Name");
            comboBox1.Items.Add("User Name");
            comboBox1.Items.Add("Is Active");

            comboBoxIsActive.Items.Add("All");
            comboBoxIsActive.Items.Add("Active Only");
            comboBoxIsActive.Items.Add("Not Active");


        }


        private void LoadDataSearch()
        {
            string FilterBy = "";
            switch (comboBox1.Text)
            {
                case "User ID":
                    {

                        FilterBy = "UserID";
                        break;
                    }
                case "Full Name":
                    {

                        FilterBy = "FullName";
                        break;

                    }
                case "User Name":
                    {

                        FilterBy = "UserName";
                        break;
                    }
                default:
                    {
                        FilterBy = "None";
                        break;
                    }

            }

            if (textBox1.Text.Trim() == "" || FilterBy == "None")
            {
                DTAllUsers.DefaultView.RowFilter = "";
                labelRecords.Text = DTAllUsers.Rows.Count.ToString();
                return;
            }

            if (FilterBy != "UserName" && FilterBy != "FullName")
            {
                if (int.TryParse(textBox1.Text, out int value))
                {
                    DTAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterBy, value);

                    return;
                }

            }
            else
            {
                DTAllUsers.DefaultView.RowFilter = string.Format("[{0}]like'{1}%'", FilterBy, textBox1.Text.Trim());
                labelRecords.Text = dataGridView1.Rows.Count.ToString();
            }


        }

        private void LoadDataSearchIsActive()
        {
            string Filterby = "";
            string FilterColumn = "IsActive";

            switch (comboBoxIsActive.Text)
            {

                case "Active Only":
                    {

                        Filterby = "1";
                        break;
                    }
                case "Not Active":
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
                DTAllUsers.DefaultView.RowFilter = "";

            }
            else
            {
                DTAllUsers.DefaultView.RowFilter = string.Format("[{0}]={1}", FilterColumn, Filterby);

            }
            labelRecords.Text = dataGridView1.Rows.Count.ToString();

        }

    


   

        private void SelectIsActive()
        {


            switch (comboBoxIsActive.SelectedItem.ToString())
            {
                case "All":
                    {
                        
                        break;
                    }
                case "ActiveOnly":
                    {
                        
                        break;
                    }
                case "NotActive":
                    {
                        

                        break;
                    }
                default: break;


            }


        }

        
        private void FormUsers_Load(object sender, EventArgs e)
        {
            RefreshData();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            

            }

        private void comboBoxIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataSearchIsActive();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDataSearch();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
            if (comboBox1.Text=="Is Active")
            {
                comboBoxIsActive.Visible = true;
                textBox1.Visible = false;
                comboBoxIsActive.Focus();
                comboBoxIsActive.SelectedIndex = 0;



            }else
            {
                textBox1.Visible = (comboBox1.Text != "None");
                comboBoxIsActive.Visible = false;
                textBox1.Text = "";
                textBox1.Focus();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form = new FormAddNewUser();
            Form.ShowDialog();
            RefreshData();

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser Form=new FormAddNewUser();
            Form.ShowDialog();
            RefreshData();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNewUser Form = new FormAddNewUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            RefreshData();


        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUsers.DeleteUser((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Deleted Succefully");
            }else
            {
                MessageBox.Show("this User is related to another data in the system");
            }
            RefreshData();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUserInfo form = new FormUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            form.ShowDialog();


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
                    Form Form=new FormChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            RefreshData();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Feature will be here soon");

        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this Feature will be here soon");

        }
    }
    }

