using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsApplicationTypesDL
    {
        public static DataTable ListApplicationTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "select * from ApplicationTypes";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {

                    dataTable.Load(Reader);

                }
                Reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                Connection.Close();
            }

            return dataTable;






        }

        public static bool UpdateApplicationTypes(int AppID,string AppName,decimal AppFees)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"update ApplicationTypes set ApplicationFees=@AppFees,
                ApplicationTypeTitle=@AppName where ApplicationTypeID=@AppID";
 
            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@AppFees", AppFees);
            cmd.Parameters.AddWithValue("@AppName", AppName);
            cmd.Parameters.AddWithValue("@AppID", AppID);

            try
            {
                Connection.Open();
               RowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                Connection.Close();
            }


            return (RowsAffected > 0);


        }

        public static bool FindApplicationType(int AppID,ref string AppName,ref decimal Appfee)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from ApplicationTypes where ApplicationTypeID=@ApplicationTypeID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", AppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    AppID = (int)reader["ApplicationTypeID"];
                    AppName = (string)reader["ApplicationTypeTitle"];
                    Appfee = (decimal)reader["ApplicationFees"]; ;
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;









        }

    }
}
