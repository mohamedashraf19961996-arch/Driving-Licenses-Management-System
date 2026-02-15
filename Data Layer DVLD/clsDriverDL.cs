using DTO.DVLD;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Layer_DVLD
{
    public class clsDriverDL
    {
        public static bool GetDriverByID(int DriverID, ref DTODrivers Driver)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "SELECT * FROM Drivers WHERE DriverID=@DriverID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Driver.DriverID = (int)reader["DriverID"];
                    Driver.PersonID = (int)reader["PersonID"];
                    Driver.UserID = (int)reader["CreatedByUserID"];
                    Driver.CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFound = true;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogsException.AddExceptionToEventLog(ex.Message);


            }
            finally { Connection.Close(); }
            return IsFound;

        }

        public static bool GetDriverByPersonID(int PersonID, ref DTODrivers Driver)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "SELECT * FROM Drivers WHERE PersonID=@PersonID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Driver.DriverID = (int)reader["DriverID"];
                    Driver.PersonID = (int)reader["PersonID"];
                    Driver.UserID = (int)reader["CreatedByUserID"];
                    Driver.CreatedDate = (DateTime)reader["CreatedDate"];
                    IsFound = true;

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally { Connection.Close(); }
            return IsFound;

        }

        public static bool DeleteDriver(int DriverID)
        {
            int RowsAffected = -1;
                
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "delete FROM Drivers WHERE DriverID=@DriverID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                
                RowsAffected = command.ExecuteNonQuery();
                

            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);


            }
            finally { Connection.Close(); }


            return (RowsAffected != -1);


        }

        public static int AddNewDriver(DTODrivers NewDriver)
        {
            int DriverID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into Drivers(PersonID,CreatedByUserID,CreatedDate)values(@PersonID,@CreatedByUserID,
                              @CreatedDate);
                              Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", NewDriver.PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID",NewDriver.UserID);
            command.Parameters.AddWithValue("@CreatedDate", NewDriver.CreatedDate);
            

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    DriverID = insertedID;

                }


            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
            }
            finally
            {
                connection.Close();
            }




            return DriverID;













        }

        public static bool UpdateDriver(DTODrivers UpdatedDriver)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Drivers set PersonID=@PersonID,CreatedByUserID=@CreatedByUserID
                where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", UpdatedDriver.PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID",UpdatedDriver.UserID);
            
            command.Parameters.AddWithValue("@DriverID",UpdatedDriver.DriverID);
            
            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
            }
            finally
            {
                connection.Close();
            }



            return (RowsAffected > 0);

        }


        public static DataTable ListDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select * from Drivers_View";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog (ex.Message);

            }
            finally
            {
                connection.Close();
            }



            return dt;











        }

        public static DataTable ListDriverLicenseInfo(int PersonID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select Drivers.DriverID,Licenses.LicenseID,Licenses.IssueDate,Licenses.ExpirationDate,LicenseClasses.ClassName,Licenses.IsActive from Drivers inner join Licenses on Drivers.DriverID=Licenses.DriverID
                            inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass
                            where Drivers.PersonID=@PersonID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                connection.Close();
            }



            return dt;











        }





    }
}
