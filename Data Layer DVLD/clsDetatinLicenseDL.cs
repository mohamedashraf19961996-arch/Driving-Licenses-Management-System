using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsDetatinLicenseDL
    {

        public static bool Find(int DetainID, ref DTODetainLicense DetainLicense)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select * from DetainedLicenses 
                                where DetainID =@DetainID";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);


            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DetainLicense.DetainID = (int)reader["DetainID"];
                    DetainLicense.LicenseID = (int)reader["LicenseID"];
                    DetainLicense.DetainDate = (DateTime)reader["DetainDate"];
                    DetainLicense.FineFees = (decimal)reader["FineFees"];
                    DetainLicense.CreatedByUserID = (int)reader["CreatedByUserID"];
                    DetainLicense.IsReleased = (bool)reader["IsReleased"];
                    if (reader["ReleaseDate"] != System.DBNull.Value)
                    {
                        DetainLicense.ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    DetainLicense.ReleaseDate = null;


                    if (reader["ReleasedByUserID"] != System.DBNull.Value)
                    { DetainLicense.ReleasedbyUserID = (int)reader["ReleasedByUserID"]; }
                    else DetainLicense.ReleasedbyUserID = -1;

                    if (reader["ReleaseApplicationID"] != System.DBNull.Value)
                    {
                        DetainLicense.ReleaseAppId = (int)reader["ReleaseApplicationID"];
                    }
                    else DetainLicense.ReleaseAppId = -1;

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



        public static bool FindbyLicenseID(int LicenseID, ref DTODetainLicense DetainLicense)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select top 1 * from DetainedLicenses 
                                where LicenseID =@LicenseID order by DetainID desc";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);


            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DetainLicense.DetainID = (int)reader["DetainID"];
                    DetainLicense.LicenseID = (int)reader["LicenseID"];
                    DetainLicense.DetainDate = (DateTime)reader["DetainDate"];
                    DetainLicense.FineFees = (decimal)reader["FineFees"];
                    DetainLicense.CreatedByUserID = (int)reader["CreatedByUserID"];
                    DetainLicense.IsReleased = (bool)reader["IsReleased"];
                    if (reader["ReleaseDate"] != System.DBNull.Value)
                    {
                        DetainLicense.ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    else DetainLicense.ReleaseDate = null;


                    if (reader["ReleasedByUserID"] != System.DBNull.Value)
                    { DetainLicense.ReleasedbyUserID = (int)reader["ReleasedByUserID"]; }
                    else DetainLicense.ReleasedbyUserID = -1;

                    if (reader["ReleaseApplicationID"] != System.DBNull.Value)
                    {
                        DetainLicense.ReleaseAppId = (int)reader["ReleaseApplicationID"];
                    }
                    else DetainLicense.ReleaseAppId = -1;

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

        public static bool Delete(int DetainID)
        {
            int RowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "delete FROM DetainedLicenses WHERE DetainID=@DetainID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();

                RowsAffected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            finally { Connection.Close(); }


            return (RowsAffected != -1);











        }

        public static DataTable ListDetainLicense()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select DetainID,DetainedLicenses.LicenseID,DetainDate,DetainedLicenses.IsReleased,FineFees,ReleaseDate,People.NationalNo,People.FirstName+' '+People.SecondName+' '+People.ThirdName+' '+People.LastName as FullName,ReleaseApplicationID from DetainedLicenses
                                        inner join Licenses on DetainedLicenses.LicenseID=Licenses.LicenseID
                                        inner join Drivers on Drivers.DriverID=Licenses.DriverID
                                        inner join People on People.PersonID=Drivers.PersonID";
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
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                connection.Close();
            }



            return dt;









        }

        public static int AddNewDetainLicense(DTODetainLicense detainLicense)
        {
            int DetainID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased)values(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased);
                              Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseID", detainLicense.LicenseID);
            command.Parameters.AddWithValue("@DetainDate", detainLicense.DetainDate);
            command.Parameters.AddWithValue("@FineFees", detainLicense.FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", detainLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", detainLicense.IsReleased);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    DetainID = insertedID;

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




            return DetainID;







        }

        public static bool Update(DTODetainLicense detainLicense)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Licenses set LicenseID=@LicenseID,DetainDate=@DetainDate,
                FineFees=@FineFees,CreatedByUserID=@CreatedByUserID,IsReleased=@IsReleased where DetainID=@DetainID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@LicenseID", detainLicense.LicenseID);
            command.Parameters.AddWithValue("@DetainDate", detainLicense.DetainDate);
            command.Parameters.AddWithValue("@FineFees", detainLicense.FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", detainLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", detainLicense.IsReleased);

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

        public static bool ReleaseLicense(int DetainID, DTODetainLicense detainLicense)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update DetainedLicenses set ReleaseDate=@ReleaseDate,ReleasedByUserID=@ReleasedByUserID,ReleaseApplicationID=@ReleaseApplicationID,IsReleased=1 where DetainID=@DetainID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ReleaseDate", detainLicense.ReleaseDate);
            command.Parameters.AddWithValue("@ReleasedByUserID", detainLicense.ReleasedbyUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", detainLicense.ReleaseAppId);
            command.Parameters.AddWithValue("@DetainID",DetainID);

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

        public static bool IsLicenseReleased(int detainID)
        {
            bool IsReleased = false;
            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select IsReleased=1 from DetainedLicenses 
                                where DetainID =@DetainID and IsReleased=1";
            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@DetainID", detainID);


            try
            {
                Connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null)
                {
                    IsReleased = true;
                }



            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
                IsReleased = false;

            }
            finally { Connection.Close(); }



            return IsReleased;



        }
    }
}
