using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsInternationlLicensesDL
    {

        public static bool FindByID(int InternationalLicenseID,ref DTOInternationlLicenses InternationlLicense)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = @"select * from InternationalLicenses 
                            where InternationalLicenseID=@InternationalLicenseID
                            order by InternationalLicenseID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    InternationlLicense.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    InternationlLicense.ApplicationID = (int)reader["ApplicationID"];
                    InternationlLicense.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    InternationlLicense.DriverID = (int)reader["DriverID"];
                    InternationlLicense.IsActive = (bool)reader["IsActive"];
                    InternationlLicense.IssueDate = (DateTime)reader["IssueDate"];
                    InternationlLicense.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    InternationlLicense.CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static bool FindByLocalDriverLicenseID(int LocalDriverLicenseID,ref DTOInternationlLicenses InternationlLicense)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = @"select * from InternationalLicenses 
                            where IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID
                            order by InternationalLicenseID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalDriverLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    InternationlLicense.InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    InternationlLicense.ApplicationID = (int)reader["ApplicationID"];
                    InternationlLicense.IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    InternationlLicense.DriverID = (int)reader["DriverID"];
                    InternationlLicense.IsActive = (bool)reader["IsActive"];
                    InternationlLicense.IssueDate = (DateTime)reader["IssueDate"];
                    InternationlLicense.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    InternationlLicense.CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static bool Delete(int InternationalLicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from InternationalLicenses where InternationalLicenseID=@InternationalLicenseID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
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

        public static int AddNew(DTOInternationlLicenses InternationlLicense)
        {
            int InternationlLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into InternationalLicenses(ApplicationID,DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                                values(@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                                  Select Scope_Identity()";
            
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", InternationlLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", InternationlLicense.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", InternationlLicense.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", InternationlLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", InternationlLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", InternationlLicense.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", InternationlLicense.CreatedByUserID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    InternationlLicenseID = insertedID;

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




            return InternationlLicenseID;



        }

        public static bool Update(DTOInternationlLicenses InternationlLicense)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update InternationalLicenses set ApplicationID=@ApplicationID,DriverID=@DriverID,IssuedUsingLocalLicenseID=@IssuedUsingLocalLicenseID,
                                    IssueDate=@IssueDate,ExpirationDate=@ExpirationDate,IsActive=@IsActive,CreatedByUserID=@CreatedByUserID where InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", InternationlLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", InternationlLicense.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", InternationlLicense.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", InternationlLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", InternationlLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", InternationlLicense.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", InternationlLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationlLicense.InternationalLicenseID);


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

        public static DataTable ListInternationalLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select InternationalLicenseID,ApplicationID,IssuedUsingLocalLicenseID,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,IssueDate,ExpirationDate,IsActive from InternationalLicenses
                                                        inner join Drivers on Drivers.DriverID=InternationalLicenses.DriverID
                                                        inner join People on Drivers.PersonID=People.PersonID
                                                        order by InternationalLicenseID desc";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {        dt.Load(reader);
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

        public static DataTable ListInernationalLicenseByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select InternationalLicenseID,ApplicationID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive from InternationalLicenses
                                                    where DriverID=@DriverID order by InternationalLicenseID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                { dt.Load(reader); }
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

        public static bool DoseInternationalLicenseActive(int InternationalLicenseID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select Found=1 from InternationalLicenses where IsActive=1 and InternationalLicenseID=@InternationalLicenseID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            
            try
            {
                connection.Open();
                object ob = command.ExecuteScalar();
                if (ob != null)
                {
                    IsFound = true;
                }

            }
            catch (System.Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                IsFound = false;

            }
            finally
            {
                connection.Close();
            }


            return IsFound;







        }



    }


    }
