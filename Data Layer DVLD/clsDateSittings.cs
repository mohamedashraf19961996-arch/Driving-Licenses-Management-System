using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Data_Layer_DVLD
{
    internal class clsDateSittings
    {

        //public static string ConnectingString = "Server=.;Database=DVLD;User ID=sa;Password=123456";

        public static string ConnectingString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        

    }
}
