using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Layer_DVLD
{
    public class clsLocalDriverLicenceApplicationDL
    {
        public static bool GetLocalLicenceAppbyID(int LocalLicenceAppID,ref int ApplicationID,ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenceAppID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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

        public static bool GetLocalLicenceAppbyAppID( ref int LocalLicenceAppID,  int ApplicationID, ref int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from LocalDrivingLicenseApplications where ApplicationID=@ApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LocalLicenceAppID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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
        public static bool DeleteLocalLicenceApp(int LocalLicenceAppID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenceAppID);
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

        public static DataTable GetAllLocalLicenceApp()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "select * from LocalDrivingLicenseApplications_View";
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

        public static int AddNewLocalLicenceApp(int ApplicationID,int LicenseClassID)
        {
            int AppID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into LocalDrivingLicenseApplications(ApplicationID,LicenseClassID)
                            values(@ApplicationID,@LicenseClassID);  
                                Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool UpdateLocalLicenceApp(int LocalLicenceAppID, int ApplicationID, int LicenseClassID)
        {

            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update LocalDrivingLicenseApplications set ApplicationID=@ApplicationID,LicenseClassID=@LicenseClassID
                 where LocalDrivingLicenseApplicationID=@LocalLicenceAppID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LocalLicenceAppID", LocalLicenceAppID);
            

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

        public static int GetCountOfPassedTestsForLicenseApp(int LocalDrivingLicenseID)
        {
            int PassedTest = -1;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select PassedTests=count(TestAppointments.TestAppointmentID) from LocalDrivingLicenseApplications 
            inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID
            inner join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and Tests.TestResult=1";

            SqlCommand command=new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);

            try
            {
                Connection.Open();

                object Result=command.ExecuteScalar();

                if (int.TryParse(Result.ToString(), out int CountPassedTest)) {

                    PassedTest = CountPassedTest;
                }
                    

            }catch(Exception ex)  
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return PassedTest;
        }

        public static bool DoseAttendTestType(int TestypeId,int LocalDrivingLicenseId)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select isFound=1 from LocalDrivingLicenseApplications 
                            inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID
                            where TestTypeID=@TestypeId and IsLocked=1 and LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseId
                            ";

            SqlCommand Command=new SqlCommand(Query, connection);

            Command.Parameters.AddWithValue("@TestypeId", TestypeId);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseId", LocalDrivingLicenseId);

            bool IsFound = false;

            try
            {
                connection.Open();

                object ob=Command.ExecuteScalar();
                if (ob != null)
                {
                    IsFound = true;

                }

            }
            catch(Exception ex) {

                IsFound = false;
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return IsFound;


        }

        public static bool DosePassTestType(int LocalDrivingLicenseID,int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select top 1 Tests.TestResult from LocalDrivingLicenseApplications 
                            inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID
                            inner join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TestAppointments.TestTypeID=@TestTypeID and Tests.TestResult=1
                            order by TestAppointments.TestAppointmentID desc";

            SqlCommand command=new SqlCommand(Query,connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object obj=command.ExecuteScalar();
                if (obj != null)
                {

                    isFound=true;
                }

            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);


                isFound = false;


            }
            finally
            { connection.Close(); }


            return isFound;




        }

        public static int TotalTrialsPerTest(int TestTypeID, int LocalDrivingLicenseID)
        {
            int Trials = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select TotalTrials=count(TestID)from LocalDrivingLicenseApplications 
            inner join TestAppointments on LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID
            inner join Tests on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID and TestAppointments.TestTypeID=@TestTypeID";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseID", LocalDrivingLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    Trials = insertedID;

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




            return Trials;


        }

        public static bool IsThereAnActiveScaduledTest(int LocalDriverLicenseId,int TestTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"
            SELECT top 1 Found=1
    FROM LocalDrivingLicenseApplications INNER JOIN
         TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=TestAppointments.LocalDrivingLicenseApplicationID 
   WHERE
       (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID)  
       AND(TestAppointments.TestTypeID=@TestTypeID) and isLocked=0
       ORDER BY TestAppointments.TestAppointmentID desc;";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDriverLicenseId);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object obj = command.ExecuteScalar();
                if (obj != null)
                {

                    isFound = true;
                }

            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);


                isFound = false;


            }
            finally
            { connection.Close(); }


            return isFound;




        }



    }


}
