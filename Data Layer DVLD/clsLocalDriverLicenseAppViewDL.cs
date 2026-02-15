using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsLocalDriverLicenseAppViewDL
    {

        public static DataTable GetAllDriverLicenseView()
        {
            DataTable dt=new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select * from LocalDrivingLicenseApplications_View";
            SqlCommand command=new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex) {

                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally { connection.Close(); }


            return dt;







        }




    }
}
