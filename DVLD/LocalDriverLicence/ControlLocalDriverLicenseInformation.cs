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
    public partial class ControlLocalDriverLicenseInformation : UserControl
    {
        public ControlLocalDriverLicenseInformation()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        public clsLocalDrivingLicenseApplications App;
        private int _AppID;
        public int AppId1
        {
            get {  return _AppID; }
        }

        public void ResetDefault()
        {
            labelLDID.Text = "[???]";
            labelPassedTest.Text = "[???]";
            labelType.Text = "[???]";
            controlAppInformation1.ResetDefault();

        }

        private void FillControlWithdata()
        {
            controlAppInformation1.LoadData(App._application.ApplicationID);

            labelLDID.Text = App._LocalDrivingLicenseAppID.ToString();
            labelPassedTest.Text = App.GetCountOfPassedTestsForLicenseApp().ToString();
            labelType.Text = App.licenceClass._DTOLicenceClasses.ClassName;
        }
        public void LoadData(int LocalLicenseId)
        {
            App = clsLocalDrivingLicenseApplications.GetLocalDrivingLicenseApplicationsByID(LocalLicenseId);

            if (App == null)
            {
                ResetDefault();
                MessageBox.Show("this Application is not Found");
                return;
            }

            _AppID = LocalLicenseId;
            FillControlWithdata();


        }
        private void ControlLocalDriverLicenseInformation_Load(object sender, EventArgs e)
        {
            
        }

        private void controlAppInformation1_Load(object sender, EventArgs e)
        {

        }
    }
}
