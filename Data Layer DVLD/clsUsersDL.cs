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
    public class clsUsersDL
    {

        public static bool GetUserByUserID(ref DTOUsers User,int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from Users where UserID=@UserID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID",UserID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    User.UserID = (int)reader["UserID"];
                    User.PersonID = (int)reader["PersonID"];
                    User.UserName = (string)reader["UserName"];
                    User.Password = (string)reader["Password"];
                    User.IsActive = (bool)reader["IsActive"];

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

        public static bool GetUserByPersonID(ref DTOUsers User, int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from Users where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    User.UserID = (int)reader["UserID"];
                    User.UserName = (string)reader["UserName"];
                    User.Password = (string)reader["Password"];
                    User.IsActive = (bool)reader["IsActive"];

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

        public static bool IsUserExistbyPersonID(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select Found = 1 from Users where PersonID=@PersonID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
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

        public static bool IsUserExistbyUserID(int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select Found = 1 from Users where UserID=@UserID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool IsUserExistbyUserName(string UserName)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select Found = 1 from Users where UserName=@UserName;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
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
        public static int AddNewUser(DTOUsers User)
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Insert into Users(PersonID,UserName,Password,IsActive)values(@PersonID,@UserName,
                              @Password,@IsActive);
                              Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", User.PersonID);
            command.Parameters.AddWithValue("@UserName",User.UserName);
            command.Parameters.AddWithValue("@Password", User.Password);
            command.Parameters.AddWithValue("@IsActive", User.IsActive);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {

                    UserID = insertedID;

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




            return UserID;



        }

        public static bool DeleteUser(int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            int RowsAffected = 0;
            string Query = "Delete from Users where UserID=@UserID;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
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

        public static bool UpdateUser(DTOUsers User)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Users set PersonID=@PersonID,UserName=@UserName,Password=@Password,
                                    IsActive=@IsActive where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", User.PersonID);
            command.Parameters.AddWithValue("@UserName",User.UserName);
            command.Parameters.AddWithValue("@Password",User.Password);
            command.Parameters.AddWithValue("@IsActive",User.IsActive);
            command.Parameters.AddWithValue("@UserID", User.UserID);
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

        public static DataTable ListUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"select UserID,Users.PersonID,UserName,FullName=FirstName+' '+SecondName+' ' +ThirdName+' '
                +LastName,Password,IsActive   from Users inner join People on Users.PersonID=People.PersonID";
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

        public static bool GetUserByUserNameAndPassword(ref DTOUsers CurrentUser,string UserName,string Password)
        {
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            bool isFound = false;
            string Query = "Select * from Users where UserName=@UserName and Password=@Password;";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    CurrentUser.UserID = (int)reader["UserID"];
                    CurrentUser.PersonID = (int)reader["PersonID"];
                    CurrentUser.IsActive = (bool)reader["IsActive"];
                    CurrentUser.UserName = (string)reader["UserName"];
                    CurrentUser.Password = (string)reader["Password"];

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

        public static bool ChangeUserPassword(int UserID,string Password)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDateSittings.ConnectingString);
            string Query = @"Update Users set Password=@Password where UserID=@UserID";
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@Password",Password);

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
