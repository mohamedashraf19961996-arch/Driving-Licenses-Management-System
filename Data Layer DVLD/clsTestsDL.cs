using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class clsTestsDL
    {
        public static bool GetTestByID(int TestID, ref DTOTests Test)
        {

            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from Tests where TestID=@TestID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Test.TestID = (int)reader["TestID"];
                    Test.TestAppointmentID = (int)reader["TestAppointmentID"];
                    Test.TestResult = (bool)reader["TestResult"];
                    Test.UserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        Test.Notes = (string)reader["Notes"];
                    }
                    else Test.Notes = "";

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

        public static bool GetTestByPersonAndTestTypeAndLicenseClass(int PersonID,int TestTypeId,int ClassLicenseID,ref DTOTests Test)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = @"select top 1 Tests.TestID,Tests.TestAppointmentID,Tests.Notes,Tests.TestResult,Tests.CreatedByUserID from Tests 
	                            inner join TestAppointments on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                            	inner join LocalDrivingLicenseApplications on TestAppointments.LocalDrivingLicenseApplicationID=LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
	                            inner join Applications on LocalDrivingLicenseApplications.ApplicationID=Applications.ApplicationID
                                where (LocalDrivingLicenseApplications.LicenseClassID=@ClassLicenseID) AND
                                (Applications.ApplicantPersonID=@PersonID) AND
                                (TestAppointments.TestTypeID=@TestTypeId)
                                ORDER BY Tests.TestAppointmentID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassLicenseID", ClassLicenseID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@TestTypeId", TestTypeId);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Test.TestID = (int)reader["TestID"];
                    Test.TestAppointmentID = (int)reader["TestAppointmentID"];
                    Test.TestResult = (bool)reader["TestResult"];
                    Test.UserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        Test.Notes = (string)reader["Notes"];
                    }
                    else Test.Notes = "";

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
        public static int AddNewTest(DTOTests Test)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID)
                                  values(@TestAppointmentID,@TestResult,
                                  @Notes,@CreatedByUserID);
                                Update TestAppointments set IsLocked=1 where TestAppointmentID=@TestAppointmentID;
                                Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", Test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", Test.TestResult);
            command.Parameters.AddWithValue("@CreatedByUserID", Test.UserID);

            if (Test.Notes == "")
            {
                 command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
             }
            else
            {
                command.Parameters.AddWithValue("@Notes", Test.Notes);
            }


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    TestID = insertedID;

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




            return TestID;








        }

        public static bool UpdateTest(DTOTests Test)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Tests set TestAppointmentID=@TestAppointmentID,TestResult=@TestResult,
                Notes=@Notes,CreatedByUserID=@CreatedByUserID WHERE TestID=@TestID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", Test.TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", Test.TestResult);
            if (Test.Notes != null)
            {
                command.Parameters.AddWithValue("@Notes", Test.Notes);
            
            }else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", Test.UserID);
            command.Parameters.AddWithValue("@TestID", Test.TestID);

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

        public static bool DeleteTest(int TestID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from Tests where TestID=@TestID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
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

       

    }
}
