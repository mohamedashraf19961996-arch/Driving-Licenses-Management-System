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
    public partial class FormAppTypes : Form
    {
        public FormAppTypes()
        {
            InitializeComponent();
        }
        DataTable dt;

        private void ResetDefault()
        {
            dt = clsApplicationTypes.ListAppType();
            dataGridView1.DataSource = dt;
            labelRecords.Text=dataGridView1.Rows.Count.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "App ID";
                dataGridView1.Columns[0].Width = 60;

                dataGridView1.Columns[1].HeaderText = "App Type Name";
                dataGridView1.Columns[1].Width = 300;

                dataGridView1.Columns[2].HeaderText = "App Fees";
                dataGridView1.Columns[2].Width = 90;


            }
        }
        private void FormAppTypes_Load(object sender, EventArgs e)
        {
                ResetDefault();            

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editAppTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form=new FormEditAppType((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormAppTypes_Load(null, null);
        }
    }
}
