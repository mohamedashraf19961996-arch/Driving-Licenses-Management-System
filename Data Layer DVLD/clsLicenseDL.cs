using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO.DVLD.DTOLicense;

namespace Data_Layer_DVLD
{
    public class clsLicenseDL
    {
        public static bool FindLicenseByLicenseID(int LicenseID,ref DTOLicense license)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "SELECT * FROM Licenses WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    license.LicenseID = (int)reader["LicenseID"];
                    license.DriverID = (int)reader["DriverID"];
                    license.ApplicationID = (int)reader["ApplicationID"];
                    license.LicenseClassID = (int)reader["LicenseClass"];
                    license.CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] == System.DBNull.Value)
                    {
                        license.Notes = "";
                    }
                    else { license.Notes = (string)reader["Notes"]; }
                        license.IsActive = (bool)reader["IsActive"];
                    license.PaidFees = (decimal)reader["PaidFees"];
                    license.IssueDate = (DateTime)reader["IssueDate"];
                    license.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    license.issueReason = (DTOLicense.enIssueReason)(byte)reader["IssueReason"];

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

        public static bool FindLicenseByAppAndDriverAndLicenseClassID(int PersonID,int LicenseClassID, ref DTOLicense license)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"SELECT top 1 LicenseID,ApplicationID,Licenses.DriverID,IssueDate,ExpirationDate,Notes,PaidFees,IsActive
                                ,Licenses.LicenseClass,IssueReason,Licenses.CreatedByUserID
                                FROM Licenses 
                                inner join Drivers on Licenses.DriverID=Drivers.DriverID 
                                WHERE Drivers.PersonID=@PersonID AND Licenses.LicenseClass=@LicenseClass order by LicenseID desc";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);


            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    license.DriverID = (int)reader["DriverID"];
                    license.LicenseID = (int)reader["LicenseID"];
                    license.ApplicationID = (int)reader["ApplicationID"];
                    license.LicenseClassID = (int)reader["LicenseClass"];
                    license.CreatedByUserID = (int)reader["CreatedByUserID"];
                    if (reader["Notes"] != System.DBNull.Value)
                    {
                        license.Notes = (string)reader["Notes"];
                    }
                    else license.Notes = "";
                    license.IsActive = (bool)reader["IsActive"];
                    license.PaidFees = (decimal)reader["PaidFees"];
                    license.IssueDate = (DateTime)reader["IssueDate"];
                    license.ExpirationDate = (DateTime)reader["ExpirationDate"];
                    license.issueReason = (DTOLicense.enIssueReason)(byte)reader["IssueReason"];

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

        public static bool Delete(int LicenseID)
        {
            int RowsAffected = -1;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "delete FROM Drivers WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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

        public static  DataTable ListLicenses(int DriverID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select LicenseID,DriverID,LicenseClasses.ClassName,IssueDate,ExpirationDate,
case 
when IsActive =1 then 'Active'
when IsActive=0 then 'Not Active'
end as IsActive,
case 
when IssueReason =1 then 'First Time'
when IssueReason=2 then 'Renew'
when IssueReason=3 then 'Replacement For Damage'
when IssueReason=4 then 'Replacement For Lost'
end as IssueReason
from Licenses
inner join LicenseClasses on LicenseClasses.LicenseClassID=Licenses.LicenseClass where DriverID=@DriverID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
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

        public static int AddNewLicense(DTOLicense NewLicense)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into Licenses(ApplicationID,DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,
                            IsActive,IssueReason,CreatedByUserID)values(@ApplicationID,@DriverID,
                              @LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);
                              Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ApplicationID", NewLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", NewLicense.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", NewLicense.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", NewLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", NewLicense.ExpirationDate);
            if (NewLicense.Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", NewLicense.Notes);

            }
            else command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

                command.Parameters.AddWithValue("@PaidFees", NewLicense.PaidFees);
            command.Parameters.AddWithValue("@IsActive", NewLicense.IsActive);
            command.Parameters.AddWithValue("@IssueReason", NewLicense.issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", NewLicense.CreatedByUserID);
            

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    LicenseID = insertedID;

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




            return LicenseID;







        }

        public static bool UpdateLicense(DTOLicense UpdatedLicense)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Licenses set ApplicationID=@ApplicationID,DriverID=@DriverID,
                LicenseClass=@LicenseClass,IssueDate=@IssueDate,ExpirationDate=@ExpirationDate,Notes=@Notes
                ,PaidFees=@PaidFees,IsActive=@IsActive,CreatedByUserID=@CreatedByUserID,IssueReason=@IssueReason where LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicationID", UpdatedLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", UpdatedLicense.DriverID);
            command.Parameters.AddWithValue("@LicenseClass", UpdatedLicense.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", UpdatedLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", UpdatedLicense.ExpirationDate);
            if (UpdatedLicense.Notes != "")
            {
                command.Parameters.AddWithValue("@Notes", UpdatedLicense.Notes);

            }
            else command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            command.Parameters.AddWithValue("@PaidFees", UpdatedLicense.PaidFees);
            command.Parameters.AddWithValue("@IsActive", UpdatedLicense.IsActive);
            command.Parameters.AddWithValue("@IssueReason", UpdatedLicense.issueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", UpdatedLicense.CreatedByUserID);
            command.Parameters.AddWithValue("@LicenseID", UpdatedLicense.LicenseID);
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

        public static bool DoseDriverHaveLicenseOfLicenseClass(int ApplicationID, int LicenseClassID)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select top 1 Found=1 From Licenses where ApplicationID=@ApplicationID and Licenses.LicenseClass=@LicenseClass
                            order by LicenseID desc";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClass",LicenseClassID);

            try
            {
                Connection.Open();

                object obj = command.ExecuteScalar();
                if (obj != null)
                {

                    IsFound = true;

                }

            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                IsFound = false;
            }
            finally { Connection.Close(); }


            return IsFound;







        }

        public static bool DoseLicenseIsActive(int LicenseID)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = @"select Found=1 from Licenses
                                where LicenseID=@LicenseID and IsActive=1";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            
            try
            {
                Connection.Open();

                object obj = command.ExecuteScalar();
                if (obj != null)
                {

                    IsFound = true;

                }

            }
            catch (Exception ex)
            {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);


                IsFound = false;
            }
            finally { Connection.Close(); }


            return IsFound;






        }
    
    public static bool ActivateLicense(int LicenseID,bool IsActive)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDateSittings.ConnectingString);

            string Query = "update Licenses set IsActive=@IsActive where LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(Query, Connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@IsActive", IsActive);

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


            return (RowsAffected > 0);






        }



    }

}
