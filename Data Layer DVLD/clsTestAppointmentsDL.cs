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
    public class clsTestAppointmentsDL
    {
        public static bool FindByID(int TestAppointmentID,ref DTOTestAppointment testAppointment)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from TestAppointments where TestAppointmentID=@TestAppointmentID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testAppointment.TestAppointmentID = (int)reader["TestAppointmentID"];
                    testAppointment.LocalDriverLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    testAppointment.TestTypeID = (int)reader["TestTypeID"];
                    testAppointment.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    testAppointment.PaidFees = (decimal)reader["PaidFees"];
                    testAppointment.UserID = (int)reader["CreatedByUserID"];
                    testAppointment.ISLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] != System.DBNull.Value)
                    { testAppointment.RetakeTestID = (int)reader["RetakeTestApplicationID"]; }
                    else testAppointment.RetakeTestID = -1;

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

        public static int AddNewTestAppointment(DTOTestAppointment testAppointment)
        {

            int TestAppointmentID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into TestAppointments(LocalDrivingLicenseApplicationID
                            ,TestTypeID,AppointmentDate,PaidFees,CreatedByUserID,
                            IsLocked,RetakeTestApplicationID)values(@LocalDrivingLicenseApplicationID,
                              @TestTypeID,@AppointmentDate,@PaidFees,
                              @CreatedByUserID,@IsLocked,@RetakeTestID);
                                Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", testAppointment.LocalDriverLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", testAppointment.TestTypeID);
            command.Parameters.AddWithValue("@AppointmentDate", testAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", testAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", testAppointment.UserID);
            command.Parameters.AddWithValue("@IsLocked", testAppointment.ISLocked);
            if(testAppointment.RetakeTestID==-1)
            {
                command.Parameters.AddWithValue("RetakeTestID", System.DBNull.Value);
            }else command.Parameters.AddWithValue("RetakeTestID", testAppointment.RetakeTestID);

            try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    {

                        TestAppointmentID = insertedID;

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




            return TestAppointmentID;



        }

        public static bool UpdateTestAppointment(DTOTestAppointment testAppointment,int TestAppointmentID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update TestAppointments set LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID,
                TestTypeID=@TestTypeID,AppointmentDate=@AppointmentDate,PaidFees=@PaidFees,CreatedByUserID=@CreatedByUserID,
                IsLocked=@IsLocked,RetakeTestApplicationID=@RetakeTestID where TestAppointmentID=@TestAppointmentID";
            SqlCommand command = new SqlCommand(Query, connection);
            
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", testAppointment.LocalDriverLicenseID);
            command.Parameters.AddWithValue("@TestTypeID", testAppointment.TestTypeID);
            command.Parameters.AddWithValue("@AppointmentDate", testAppointment.AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", testAppointment.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", testAppointment.UserID);
            command.Parameters.AddWithValue("@IsLocked", testAppointment.ISLocked);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            if (testAppointment.RetakeTestID == -1)
            {
                command.Parameters.AddWithValue("RetakeTestID", System.DBNull.Value);
            }
            else command.Parameters.AddWithValue("RetakeTestID", testAppointment.RetakeTestID);

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

        public static bool DeleteTestAppointment(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from TestAppointments where TestAppointmentID=@TestAppointmentID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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

        public static DataTable ListTestAppoinment()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "select * from TestAppointments";
            SqlCommand command = new SqlCommand(Query, connection);

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

        public static DataTable ListTestAppointment(int TestType,int LocalDrivingLicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select TestAppointments.TestAppointmentID,AppointmentDate,PaidFees,IsLocked,
                                case 
                                     when tests.TestResult=1 then 'Pass'
                                     when Tests.TestResult=0 then 'Not Pass'
                                        end as Result
                                        from TestAppointments 
                                        left join Tests on Tests.TestAppointmentID=TestAppointments.TestAppointmentID
                                        where TestAppointments.TestTypeID =@TestType and TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseID";
                                                                                                         
            SqlCommand command=new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestType", TestType);
            command.Parameters.AddWithValue(@"LocalDrivingLicenseID", LocalDrivingLicenseID);
            DataTable dt=new DataTable();   
            try
            {
                connection.Open();
                SqlDataReader reader= command.ExecuteReader();  
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();

            }
            catch(Exception ex) {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            return dt;


        }

        public static bool GetLastTestAppointment(int LocalDrivingLicenseApplicationID,int TestTypeID,ref DTOTestAppointment TestAppointment)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select top 1 * from TestAppointments
                                where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestTypeID=@TestTypeID 
                                order by TestAppointmentID desc";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    TestAppointment.TestAppointmentID= (int)reader["TestAppointmentID"];
                    TestAppointment.AppointmentDate = (DateTime)reader["AppointmentDate"];
                    TestAppointment.UserID = (int)reader["CreatedByUserID"];
                    TestAppointment.LocalDriverLicenseID = (int)reader["LocalDrivingLicenseApplicationID"];
                    TestAppointment.PaidFees = (decimal)reader["PaidFees"];
                    TestAppointment.ISLocked = (bool)reader["IsLocked"];
                    TestAppointment.TestTypeID = (int)reader["TestTypeID"];
                    IsFound = true;
                }

                reader.Close();
                
            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
                IsFound=false;
            }
            finally
            {
                connection.Close();
            }




            return IsFound;




        }


    }

    }

