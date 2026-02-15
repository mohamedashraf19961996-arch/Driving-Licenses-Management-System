using Data_Layer_DVLD;
using DTO.DVLD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer_DVLD
{
    public class clsUsers
    {
        public DTOUsers _User;

        enum enMode { AddNew,Update}

         enMode _Mode;
        clsPeople _Person;
       private clsUsers(DTOUsers User)
        {
            _User= User;
            _Person = clsPeople.Find(User.PersonID);
            _Mode = enMode.Update;
        }

        public clsUsers()
        {
            _User= new DTOUsers();
            _Mode= enMode.AddNew;
        }
        public static clsUsers GetUserByUserID(int UserID)
        {
            DTOUsers User = new DTOUsers();
            
            if (clsUsersDL.GetUserByUserID(ref User,UserID))
            {

                return new clsUsers(User);
            }
            else return null;

        }

        public static clsUsers GetUserByPersonID(int PersonID)
        {
            DTOUsers User = new DTOUsers();

            if (clsUsersDL.GetUserByPersonID(ref User,PersonID))
            {

                return new clsUsers(User);
            }
            else return null;

        }

        public static clsUsers GetUserByUserNameAndPassword(string UserName,string Password)
        {
            DTOUsers User = new DTOUsers();

            if (clsUsersDL.GetUserByUserNameAndPassword(ref User, UserName, Password))
            {

                return new clsUsers(User);
            }
            else return null;

        }

        private bool _AddNewUser()
        {
            this._User.UserID = clsUsersDL.AddNewUser(this._User);

            if(this._User.UserID!=0)
            {
                return true;

            }else return false;


        }

        private bool _UpdateUser()
        {
            if (clsUsersDL.UpdateUser(this._User))
            {

                return true;
            }
            else return false;
        }
         public bool Save()
                {
                    switch (_Mode)
                    {
                        case enMode.AddNew:
                            {
                                _Mode = enMode.Update;
                                if (_AddNewUser())
                                {
                                    return true;
                                }
                                else return false;




                            }
                        case enMode.Update:
                            {
                        if (_UpdateUser())
                        {
                            return true;
                        }

                        else
                        {
                            return false;
                        }
                            }
                        default: return false;


                    }

                }

        public static bool DeleteUser(int UserID)
        {
            if(clsUsersDL.DeleteUser(UserID))
            { return true; }
            else return false;




        }

        public static DataTable ListUsers()
        {

            return clsUsersDL.ListUsers();



        }

        public static clsUsers FindCurrentUser( DTOUsers CurrentUser,string Password,string UserName)
        {
            if(clsUsersDL.GetUserByUserNameAndPassword(ref CurrentUser,UserName,Password))
            {
                return new clsUsers(CurrentUser);
            }else 
                return null;


        }
        
        public static bool IsUserExsistbyPersonID(int PersonID)
        {

            if (clsUsersDL.IsUserExistbyPersonID(PersonID))
            {
                return true;
            }else
            {
                return false;
            }



        }

        public static bool IsUserExistbyUserName(string UserName)
        {

            if (clsUsersDL.IsUserExistbyUserName(UserName))
            {
                return true;
            }
            else
            {
                return false;
            }



        }


    }
}
