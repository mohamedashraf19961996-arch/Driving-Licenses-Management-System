using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer_DVLD
{
    public class ClsPersonDL
    {
        public static bool FindPerson(ref DTOPeople Person, int PersonID)
        { 
             
            bool isFound = false;
            

                
                    try
                    {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    connection.Open();
                    string Query = "Select * from People where PersonID=@PersonID;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                Person._FirstName = (string)reader["FirstName"];
                                Person._SecondName = (string)reader["SecondName"];
                                if (reader["ThirdName"] != System.DBNull.Value)
                                {
                                    Person._ThirdName = (string)reader["ThirdName"];
                                }
                                else
                                {
                                    Person._ThirdName = "";
                                }

                                Person._ForthName = (string)reader["LastName"];
                                Person._DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Person._Gender = (DTOPeople.enGender)(byte)reader["Gendor"];
                                Person._Address = (string)reader["Address"];
                                Person._PhoneNumber = (string)reader["Phone"];

                                if (reader["Email"] != System.DBNull.Value)
                                {
                                    Person._Email = (string)reader["Email"];
                                }
                                else
                                {
                                    Person._Email = "";
                                }

                                Person._NationalCountryID = (int)reader["NationalityCountryID"];
                                if (reader["ImagePath"] != System.DBNull.Value)
                                {
                                    Person._ImagePath = (string)reader["ImagePath"];

                                }
                                else
                                {
                                    Person._ImagePath = "";
                                }


                                Person._NationalNO = (string)reader["NationalNo"];
                                Person._PersonID = (int)reader["PersonID"];
                                isFound = true;
                            }
                        }
                    }
                }
                            
                }
                catch (Exception ex)
                {

                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                    isFound = false;
                }
            
                return isFound;

            



        }






        

        public static bool FindPerson(ref DTOPeople Person, string NationalNo)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    string Query = "Select * from People where NationalNo=@NationalNo;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", NationalNo);




                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Person._FirstName = (string)reader["FirstName"];
                                Person._SecondName = (string)reader["SecondName"];
                                if (reader["ThirdName"] != System.DBNull.Value)
                                {
                                    Person._ThirdName = (string)reader["ThirdName"];
                                }
                                else
                                {
                                    Person._ThirdName = "";
                                }

                                Person._ForthName = (string)reader["LastName"];
                                Person._DateOfBirth = (DateTime)reader["DateOfBirth"];
                                Person._Gender = (DTOPeople.enGender)(int)reader["Gendor"];
                                Person._Address = (string)reader["Address"];
                                Person._PhoneNumber = (string)reader["Phone"];

                                if (reader["Email"] != System.DBNull.Value)
                                {
                                    Person._Email = (string)reader["Email"];
                                }
                                else
                                {
                                    Person._Email = "";
                                }

                                Person._NationalCountryID = (int)reader["NationalityCountryID"];
                                if (reader["ImagePath"] != System.DBNull.Value)
                                {
                                    Person._ImagePath = (string)reader["ImagePath"];

                                }
                                else
                                {
                                    Person._ImagePath = "";
                                }


                                Person._NationalNO = (string)reader["NationalNo"];
                                Person._PersonID = (int)reader["PersonID"];
                                isFound = true;
                            }

                        }
                    }
                }
                                }
                    catch (Exception ex)
                    {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                isFound = false;
                    }


                    return isFound;

                




            }


        

        public static bool IsPersonExcist(string NationalNo)
        {
            bool isFound = false;
                    try
                    {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    connection.Open();

                    string Query = "Select Found = 1 from People where NationalNo=@NationalNo;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@NationalNo", NationalNo);


                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            isFound = reader.HasRows;
                        }
                    }                        }
                    }
                    catch (Exception ex)
                    {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

                isFound = false;
                    }
                

                return isFound;

            }




        
    
        
        public static int AddNewPerson(DTOPeople Person)
        {
            int PersonID = -1;


                    try
            {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    connection.Open();

                    string Query = @"Insert into people(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                            Gendor,Address,Phone,Email,NationalityCountryID,ImagePath)values(@NationalNo,@FirstName,
                              @SecondName,@ThirdName,@LastName,
                              @DateOfBirth,@Gendor,@Address,@PhoneNumber,@Email,@NationalityCountryID,@ImagePath);
                                Select Scope_Identity()";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", Person._NationalNO);
                        command.Parameters.AddWithValue("@FirstName", Person._FirstName);
                        command.Parameters.AddWithValue("@SecondName", Person._SecondName);

                        if (Person._ThirdName != null)
                        {
                            command.Parameters.AddWithValue("@ThirdName", Person._ThirdName);
                        }
                        else { command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value); }

                        command.Parameters.AddWithValue("@LastName", Person._ForthName);
                        command.Parameters.AddWithValue("@DateOfBirth", Person._DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Person._Gender);
                        command.Parameters.AddWithValue("@Address", Person._Address);
                        command.Parameters.AddWithValue("@PhoneNumber", Person._PhoneNumber);
                        command.Parameters.AddWithValue("@NationalityCountryID", Person._NationalCountryID);
                        if (Person._ImagePath != null)
                        {
                            command.Parameters.AddWithValue("@ImagePath", Person._ImagePath);
                        }
                        else { command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value); }


                        if (Person._Email != null)
                        {
                            command.Parameters.AddWithValue("@Email", Person._Email);
                        }
                        else { command.Parameters.AddWithValue("@Email", System.DBNull.Value); }


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int insertedID))
                        {

                            PersonID = insertedID;

                        }

                    }
                }

                    }
                    catch (Exception ex)
                    {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }

            return PersonID;


        }








        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;
                    try
                    {

                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {

                    connection.Open();

                    string Query = "Delete from People where PersonID=@PersonID;";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@PersonID", PersonID);


                        RowsAffected = command.ExecuteNonQuery();

                    }
                }
                }
                    catch (Exception ex)
                    {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            return (RowsAffected > 0);

        }

        public static bool UpdatePerson(DTOPeople Person)
        {
            int RowsAffected = 0;

                    try
                    {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    connection.Open();

                    string Query = @"Update People set NationalNo=@NationalNo,FirstName=@FirstName,
                SecondName=@SecondName,ThirdName=@ThirdName,LastName=@LastName,DateOfBirth=@DateOfBirth,
                Gendor=@Gendor,Address=@Address,Phone=@Phone,Email=@Email,NationalityCountryID=@NationalityCountryID,
                ImagePath=@ImagePath where PersonID=@PersonID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.AddWithValue("@NationalNo", Person._NationalNO);
                        command.Parameters.AddWithValue("@FirstName", Person._FirstName);
                        command.Parameters.AddWithValue("@SecondName", Person._SecondName);
                        if (Person._ThirdName != null)
                        {
                            command.Parameters.AddWithValue("@ThirdName", Person._ThirdName);
                        }
                        else { command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value); }

                        command.Parameters.AddWithValue("@LastName", Person._ForthName);
                        command.Parameters.AddWithValue("@DateOfBirth", Person._DateOfBirth);
                        command.Parameters.AddWithValue("@Gendor", Person._Gender);
                        command.Parameters.AddWithValue("@Address", Person._Address);
                        command.Parameters.AddWithValue("@Phone", Person._PhoneNumber);
                        command.Parameters.AddWithValue("@NationalityCountryID", Person._NationalCountryID);
                        if (Person._ImagePath != null)
                        {
                            command.Parameters.AddWithValue("@ImagePath", Person._ImagePath);
                        }
                        else { command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value); }


                        if (Person._Email != null)
                        {
                            command.Parameters.AddWithValue("@Email", Person._Email);
                        }
                        else { command.Parameters.AddWithValue("@Email", System.DBNull.Value); }
                        command.Parameters.AddWithValue("@PersonID", Person._PersonID);



                        RowsAffected = command.ExecuteNonQuery();
                    }
                }
                }
                    catch (Exception ex)
                    {
                clsEventLogsException.AddExceptionToEventLog(ex.Message);
            }
            return (RowsAffected > 0);

        }

        public static DataTable ListPeople()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString))
                {
                    connection.Open();

                    string Query = "select * from People inner join Countries on People.NationalityCountryID=Countries.CountryID";
                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                clsEventLogsException.AddExceptionToEventLog(ex.Message);

            }
            return dt;

        }

    






        public static DataTable ListPeopleByFilter(string Filter)
        {
            
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            
            string Query = $"Select * from People order by {Filter}";
            SqlCommand command = new SqlCommand(Query, connection);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;








        }
        public static DataTable ListPeopleWithFirstName(string FirstName)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where FirstName like @FirstName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
               
                    dt.Load(reader);
                
                
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;

        }

        public static DataTable ListpeopleWithSecondName(string SecondName)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where SecondName like @SecondName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@SecondName", SecondName + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;






        }

        public static DataTable ListPeopleWithThirdName(string ThirdName)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where ThirdName like @ThirdName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ThirdName", ThirdName + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;




        }

        public static DataTable ListPeopleWithForthName(string ForthName)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where LastName like @ForthName";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ForthName", ForthName + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;





        }

        public static DataTable ListPeopleWithNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where NationalNo like @NationalNo";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;








        }

        public static DataTable ListPeopleWithDateOFBirthYear(int Year)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where Year(DateOFBirth)=@Year";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Year", Year);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;





        }

        public static DataTable ListPeopleWithAddress(string Address)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where Address like @Address";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Address", Address + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;
        }
        public static DataTable ListPeopleWithEmail(string Email)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where Email like @Email";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Email", Email + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;

        }
        public static DataTable ListPeopleWithPhoneNumber(string PhoneNumber)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = "Select * from People where Phone like @PhoneNumber";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;
        }

        public static DataTable ListPeopleWithCountry(string Country)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select * from People inner join Countries on 
                            People.NationalityCountryID=Countries.CountryID where CountryName like @Country";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Country", Country + "%");
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dt.Load(reader);


                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }



            return dt;







        }

    }
}
