using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsTestTypesDL
    {
        public static bool GetTestTypeByID(int TestID,ref string TestTypeTitle,ref string TestTypeDescreption,ref decimal TestTypeFees)
        {

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from TestTypes where TestTypeID=@TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescreption = (string)reader["TestTypeDescription"];
                    TestTypeFees = (decimal)reader["TestTypeFees"];
                    
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

        public static DataTable ListTestTypes()
        {
            DataTable dataTable = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "select * from TestTypes";
            SqlCommand cmd = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
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

        public static bool UpdateTestType(int TestID,string TestTypeTitle, string TestTypeDescreption, decimal TestTypeFees)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"update TestTypes set TestTypeTitle=@TestTypeTitle,TestTypeDescription=@TestTypeDescreption,
                TestTypeFees=@TestTypeFees where TestTypeID=@TestID";

            SqlCommand cmd = new SqlCommand(Query, Connection);

            cmd.Parameters.AddWithValue("@TestTypeDescreption", TestTypeDescreption);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            cmd.Parameters.AddWithValue("@TestID", TestID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);


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






    }
}
