using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static DTO.DVLD.DTOApplication;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Layer_DVLD
{
    public class clsApplicationDL
    {

        public static bool FindBaseApp(ref DTOApplication application, int ApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from Applications where ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    application.ApplicationID = (int)reader["ApplicationID"];
                    application.ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    application.ApplicationDate = (DateTime)reader["ApplicationDate"];
                    application.ApplicationTypeID = (DTOApplication.enAppType)reader["ApplicationTypeID"];
                    application.ApplicationStatus = (DTOApplication.enApplicationStatus)(byte)reader["ApplicationStatus"];
                    application.LastStatusDate = (DateTime)reader["LastStatusDate"];
                    application.PaidFees = (decimal)reader["PaidFees"];
                    application.CreatedByUserID = (int)reader["CreatedByUserID"];
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

        public static DataTable GetAllApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "select * from Applications";
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

        public static int AddNewApplication(DTOApplication application)
        {
            int AppID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into Applications(ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,
                            CreatedByUserID)values(@ApplicantPersonID,@ApplicationDate,
                              @ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,
                              @CreatedByUserID);
                                Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", application.ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    AppID = insertedID;

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




            return AppID;






        }

        public static bool DeleteApplication(int AppID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from Applications where ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", AppID);
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

        public static bool UpdateApplication(DTOApplication application)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Applications set ApplicantPersonID=@ApplicantPersonID,ApplicationDate=@ApplicationDate,
                ApplicationTypeID=@ApplicationTypeID,ApplicationStatus=@ApplicationStatus,LastStatusDate=@LastStatusDate,PaidFees=@PaidFees,
                CreatedByUserID=@CreatedByUserID where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", application.ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", (byte)application.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
            command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);


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

        public static bool IsAppExist(int applicationID)
        {

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select Found = 1 from applications where applicationID=@applicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
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

        public static bool UpdateStatus(short Status, int ApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Applications set ApplicationStatus=@Status,LastStatusDate=@LastStatusDate
                                where ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Status", Status);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);


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

        public static int GetActiveApplicationByPersonIDandApplicationType(int PersonID, int AppTypeID)
        {
            int AppID = -1;

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select ActiveApplicationID=ApplicationID from Applications where
                             ApplicantPersonID=@PersonID and ApplicationTypeID=@AppTypeID and ApplicationStatus=1;";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AppTypeID", AppTypeID);

            try
            {
                connection.Open();

                object ob = command.ExecuteScalar();

                if (ob != null && int.TryParse(ob.ToString(), out int value))
                {
                    AppID = value;
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

            return AppID;


        }

        public static bool DosePersonHaveActiveApplication(int PersonID, int ApptypeId)
        {
            return (GetActiveApplicationByPersonIDandApplicationType(PersonID, ApptypeId) != -1);
        }

        public static bool GetActiveAppIDForLicenceClass(int PersonID, int LicenseClassID, int ApplicationTypeID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select ActiveApplicationID=Applications.ApplicationID 
                            from Applications inner join LocalDrivingLicenseApplications on
                            Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID 
                            where (Applications.ApplicantPersonID=@PersonID)
                            and (LocalDrivingLicenseApplications.LicenseClassID=@LicenseClassID) and
                            ApplicationStatus in (1,3) and (ApplicationTypeID=@ApplicationTypeID)";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

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
                IsFound = false;
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                connection.Close();
            }


            return IsFound;

        }

        public static bool DosePersonHaveActiveApplicationForLicenceClass(int PersonID, int LicenseClassID, int AppTypeId)
        {
            return (GetActiveAppIDForLicenceClass(PersonID, LicenseClassID, AppTypeId));

        }
    }
}
