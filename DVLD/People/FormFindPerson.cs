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
    public partial class FormFindPerson : Form
    {
        public FormFindPerson()
        {
            InitializeComponent();
        }


        

        public delegate void DataHandlerFormFindPerson(object sender, int PersonID);

        public event DataHandlerFormFindPerson Databack; 
        private void FormFindPerson_Load(object sender, EventArgs e)
        {
        
            
        
        }

        
        private void controlPersonalInformationWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {


            Databack?.Invoke(this,controlPersonalInformationWithFilter1.PersonId);
            this.Close();
        }
    }
}
