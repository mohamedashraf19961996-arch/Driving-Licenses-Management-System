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
    public class clsLicenceClassesDL
    {

        public static DataTable GetAllLicenceClasses()
        {
            DataTable Dt= new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from LicenseClasses";
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                { Dt.Load(reader); }
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



            return Dt;





        }

        public static bool UpdateLicenceClasses(DTOLicenceClasses licenceClasses)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update LicenseClasses set ClassName=@ClassName,
                ClassDescription=@ClassDescription,MinimumAllowedAge=@MinimumAllowedAge,DefaultValidityLength=@DefaultValidityLength,
                ClassFees=@ClassFees
                where LicenseClassID=@LicenseClassID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ClassName", licenceClasses.ClassName);
            command.Parameters.AddWithValue("@ClassDescription", licenceClasses.Description);
            command.Parameters.AddWithValue("@MinimumAllowedAge", licenceClasses.MinimumAllowedAge);
            
                command.Parameters.AddWithValue("@DefaultValidityLength", licenceClasses.DefaultValidityLength);
            
            command.Parameters.AddWithValue("@ClassFees", licenceClasses.ClassFees);
            command.Parameters.AddWithValue("@LicenseClassID", licenceClasses.ID);
            
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

        public static bool GetLicenceClassesByID(ref DTOLicenceClasses licenceClasses,int ID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from LicenseClasses where LicenseClassID=@LicenseClassID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@LicenseClassID",ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    licenceClasses.ID = (int)reader["LicenseClassID"];
                    licenceClasses.ClassName = (string)reader["ClassName"];
                    licenceClasses.Description = (string)reader["ClassDescription"];
                    licenceClasses.MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    licenceClasses.DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    licenceClasses.ClassFees = (decimal)reader["ClassFees"];
                   
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

