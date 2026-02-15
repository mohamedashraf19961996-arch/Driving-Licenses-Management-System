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
    public partial class ControlAppInformation : UserControl
    {
        public ControlAppInformation()
        {
            InitializeComponent();
        }

        private clsApplications App;
        int _AppID;
        public int AppID1
        {
            get {  return _AppID; }
        }

        public void ResetDefault()
        {
            labelApplicant.Text = "[???]";
            labelDate.Text = "[???]";
            labelFees.Text = "[???]";
            labelID.Text = "[???]";
            labelStatus.Text = "[???]";
            labelStatusDate.Text = "[???]";
            labelType.Text = "[???]";
            labelUserName.Text = "[???]";



        }

        private void FillApplicationControlWithData()
        {

            labelApplicant.Text =App._PersonInfo._Person.FullName;
            labelDate.Text = App._application.ApplicationDate.ToShortDateString();
            labelFees.Text = App._applicationType._AppFees.ToString();
            labelID.Text = App._application.ApplicationID.ToString();
            labelStatus.Text = App._application.ApplicationStatus.ToString();
            labelStatusDate.Text = App._application.LastStatusDate.ToShortDateString();
            labelType.Text = App._applicationType._AppName;
            labelUserName.Text = App._User._User.UserName;



        }
        public void LoadData(int AppId)
        {
            App = clsApplications.FindBaseApp(AppId);

            if (App == null)
            {
                ResetDefault();

                MessageBox.Show("this Application is not Found");
                return;

            }

            _AppID= AppId;
            FillApplicationControlWithData();


        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ControlAppInformation_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form Form = new FormShowPersonInformation2(App._PersonInfo._Person._PersonID);
            Form.ShowDialog();
            
        }
    }
}
