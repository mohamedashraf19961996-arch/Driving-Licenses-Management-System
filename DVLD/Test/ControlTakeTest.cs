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
    public partial class ControlTakeTest : UserControl
    {
        public ControlTakeTest()
        {
            InitializeComponent();
        }

        private clsTestAppointment _TestAppointment;

        public void LoadControlData(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);



        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
