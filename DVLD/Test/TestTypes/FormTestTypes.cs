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
    public partial class FormTestTypes : Form
    {
        public FormTestTypes()
        {
            InitializeComponent();
        }


        DataTable dt;
        private void RefreshData()
        {
            dt=clsTestTypes.ListTestTypes();
            dataGridView1.DataSource= dt;
            labelRecords.Text=dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Test ID";
                dataGridView1.Columns[0].Width = 70;

                dataGridView1.Columns[1].HeaderText = "Title";
                dataGridView1.Columns[1].Width = 80;

                dataGridView1.Columns[2].HeaderText = "Descreption";
                dataGridView1.Columns[2].Width = 250;

                dataGridView1.Columns[3].HeaderText = "Fees";
                dataGridView1.Columns[3].Width = 70;

            }

        }
        private void FormTestTypes_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Form = new FormEditTestType((int)dataGridView1.CurrentRow.Cells[0].Value);
            Form.ShowDialog();
            FormTestTypes_Load(null, null);
        }
    }
}
