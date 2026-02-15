using Data_Layer_DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsLocalDriverLicenseView
    {

        public static DataTable GetAllView()
        {
            return clsLocalDriverLicenseAppViewDL.GetAllDriverLicenseView();
        }




    }
}
