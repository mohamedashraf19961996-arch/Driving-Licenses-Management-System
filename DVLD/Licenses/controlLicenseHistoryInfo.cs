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
    public partial class controlLicenseHistoryInfo : UserControl
    {
        public controlLicenseHistoryInfo()
        {
            InitializeComponent();
        }

        

        int _PersonID=-1;

        DataTable dtLicenseHistory;
        DataTable DtInterNationalLicense;
        public int PersonID
        {
            get { return _PersonID; }
        }
        private void controlLicenseHistoryInfo_Load(object sender, EventArgs e)
        {
            
            

        }

        

        public void LoadData(int PersonID)
        {
            _PersonID = PersonID;

            
            controlPersonalInformationWithFilter1.LoadPersonInfo(PersonID);
            controlPersonalInformationWithFilter1.FilterEnabled = false;


            dtLicenseHistory = clsDrivers.ListDriverLicenseHistory(_PersonID);
            dataGridView1.DataSource = dtLicenseHistory;
             labelRecords.Text = dataGridView1.Rows.Count.ToString();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Driver ID";
                dataGridView1.Columns[0].Width = 40;

                dataGridView1.Columns[1].HeaderText = "License ID";
                dataGridView1.Columns[1].Width = 40;

                dataGridView1.Columns[2].HeaderText = "Issue Date";
                dataGridView1.Columns[2].Width = 110;

                dataGridView1.Columns[3].HeaderText = "Expiration Date";
                dataGridView1.Columns[3].Width = 110;

                dataGridView1.Columns[4].HeaderText = "Class Name";
                dataGridView1.Columns[4].Width =110;

                dataGridView1.Columns[5].HeaderText = "Is Active";
                dataGridView1.Columns[5].Width = 40;



            }

            DtInterNationalLicense = clsInternationLicenses.ListInernationalLicenseByDriverID(clsDrivers.FindDriverByPersonID(PersonID).Driver.DriverID);
            dataGridView2.DataSource = DtInterNationalLicense;
            
             labelRecords2.Text = dataGridView2.Rows.Count.ToString();

            

            if (dataGridView2.Rows.Count>0)
            {
                dataGridView2.Columns[0].HeaderText = "International License ID ";
                dataGridView2.Columns[0].Width = 40;

                dataGridView2.Columns[1].HeaderText = "Application ID";
                dataGridView2.Columns[1].Width = 40;

                dataGridView2.Columns[2].HeaderText = "Local License ID";
                dataGridView2.Columns[2].Width = 40;

                dataGridView2.Columns[3].HeaderText = "Issue Date";
                dataGridView2.Columns[3].Width = 110;

                dataGridView2.Columns[4].HeaderText = "Expiration Date";
                dataGridView2.Columns[4].Width = 110;

                dataGridView2.Columns[5].HeaderText = "Is Active";
                dataGridView2.Columns[5].Width = 40;







            }



        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
